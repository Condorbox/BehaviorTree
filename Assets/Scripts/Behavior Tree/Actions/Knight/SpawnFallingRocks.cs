using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using DG.Tweening;

public class SpawnFallingRocks : Node
{
    private Collider2D spawnAreaCollider;
    private GameObject rockProjectile;
    private int spawnCount = 4;
    private float spawnInterval = 0.3f;

    public SpawnFallingRocks(Collider2D spawnAreaCollider, GameObject rockProjectile, int spawnCount, float spawnInterval)
    {
        this.spawnAreaCollider = spawnAreaCollider;
        this.rockProjectile = rockProjectile;
        this.spawnCount = spawnCount;
        this.spawnInterval = spawnInterval;
    }

    protected override void OnStart() { }
    protected override NodeState OnUpdate()
    {
        var sequence = DOTween.Sequence();
        for (int i = 0; i < spawnCount; i++)
        {
            sequence.AppendCallback(SpawnRock);
            sequence.AppendInterval(spawnInterval);
        }

        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }

    private void SpawnRock()
    {
        float randomX = Random.Range(spawnAreaCollider.bounds.min.x, spawnAreaCollider.bounds.max.x);
        GameObject rock = Object.Instantiate(rockProjectile, new Vector3(randomX, spawnAreaCollider.bounds.min.y), Quaternion.identity);
        if (rock.TryGetComponent<Rigidbody2D>(out Rigidbody2D rockRigidbody))
        {
            rockRigidbody.AddForce(Vector2.zero);
        }
    }

    protected override void OnStop() { }
}
