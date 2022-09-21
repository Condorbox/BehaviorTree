using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;
using Tree = BehaviorTree.Tree;

public class EnemyAI : Tree
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private float lowerHealthThreshold = 5f;
    [SerializeField] private float healthRestoreRate = 0.25f;
    private float currentHealth;

    [Header("Range")]
    [SerializeField] private float chasingRange = 40f;
    [SerializeField] private float shootRange = 17f;

    [SerializeField] private Transform playerTransform;

    [Header("AI")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Material material;

    private Transform bestCoverSpot;
    [SerializeField] private Cover[] availableCovers;

    protected override void Awake()
    {
        currentHealth = maxHealth;

        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (material == null)
        {
            material = GetComponent<MeshRenderer>().material;
        }

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();

        if (root.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.red);
            agent.isStopped = true;
        }

        Heal();
    }

    protected override Node ConstructBehaviorTree()
    {
        IsCoverAvailableNode coverAvailableNode = new IsCoverAvailableNode(availableCovers, playerTransform, this);
        GoToCoverNode goToCoverNode = new GoToCoverNode(agent, this);
        HealthNode healthNode = new HealthNode(this, lowerHealthThreshold);
        IsCoverNode isCoveredNode = new IsCoverNode(playerTransform, transform);
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
        RangeNode chasingRangeNode = new RangeNode(chasingRange, playerTransform, transform, Color.yellow);
        RangeNode shootingRangeNode = new RangeNode(shootRange, playerTransform, transform, Color.red);
        ShootNode shootNode = new ShootNode(agent, this, playerTransform);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode });

        Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvailableNode, goToCoverNode });
        Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence });
        Selector tryToTakeCoverSelector = new Selector(new List<Node> { isCoveredNode, findCoverSelector });
        Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

        Node node = new Selector(new List<Node> { mainCoverSequence, shootSequence, chaseSequence });
        return node;
    }

    private void Heal()
    {
        currentHealth += healthRestoreRate * Time.deltaTime;
        Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void SetBestCoverSpot(Transform bestCoverSpot)
    {
        this.bestCoverSpot = bestCoverSpot;
    }

    public Transform GetBestCoverSpot()
    {
        return bestCoverSpot;
    }

    public float GetCurrentHealth() => currentHealth;

    private void OnMouseDown()
    {
        TakeDamage(10f);
    }
}
