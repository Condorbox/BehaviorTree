using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Tree = BehaviorTree.Tree;
public class KnightAI : Tree
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Collider2D spawnRockCollider;
    [SerializeField] private GameObject rockPrefab;

    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        base.Awake();
    }


    protected override Node ConstructBehaviorTree()
    {
        Jump jump = new Jump(3, 20, 0.5f, 1.3f, true, animator, playerTransform, transform, rb);
        FacePlayer facePlayer = new FacePlayer(playerTransform, transform);

        Shoot shoot = new Shoot(new List<Weapon> { weapon }, true, transform, weaponTransform);
        SpawnFallingRocks spawnFallingRocks = new SpawnFallingRocks(spawnRockCollider, rockPrefab, 3, 1.2f);

        Sequence sequenceJump = new Sequence(new List<Node> { jump, facePlayer });
        Wait waitJump = new Wait(sequenceJump, 1f);

        Sequence sequenceHammer = new Sequence(new List<Node> { facePlayer, shoot, spawnFallingRocks });
        Wait waitHammer = new Wait(sequenceHammer, 1.5f);

        return new RandomComposite(new List<Node> { waitJump, waitHammer });
    }
}
