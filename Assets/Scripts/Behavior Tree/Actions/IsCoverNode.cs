using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class IsCoverNode : Node
{
    private Transform target;
    private Transform origin;

    public IsCoverNode(Transform target, Transform origin)
    {
        this.target = target;
        this.origin = origin;
    }

    protected override void OnStart() { }

    protected override NodeState OnUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin.position, target.position - origin.position, out hit))
        {
            if (hit.collider.transform != target)
            {
                return NodeState.SUCCESS;
            }
        }

        return NodeState.FAILURE;
    }

    protected override void OnStop() { }
}
