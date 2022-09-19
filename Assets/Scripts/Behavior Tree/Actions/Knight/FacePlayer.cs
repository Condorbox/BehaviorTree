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

    public override NodeState Evaluate()
    {
        var scale = transform.localScale;
        scale.x = transform.position.x > playerTransform.position.x ? -baseScaleX : baseScaleX;
        transform.localScale = scale;
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
