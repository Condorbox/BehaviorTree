using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class FacePlayer : Node
{

    private float baseScaleX;
    private Transform playerTransform;
    private Transform transform;

    public FacePlayer(Transform playerTransform, Transform transform)
    {
        this.playerTransform = playerTransform;
        this.transform = transform;
        this.baseScaleX = transform.localScale.x;
    }

    protected override void OnStart() { }

    protected override NodeState OnUpdate()
    {
        var scale = transform.localScale;
        scale.x = transform.position.x > playerTransform.position.x ? -baseScaleX : baseScaleX;
        transform.localScale = scale;
        return NodeState.SUCCESS;
    }

    protected override void OnStop() { }
}
