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

    public override NodeState Evaluate()
    {
        RaycastHit hit;
        if(Physics.Raycast(origin.position, target.position - origin.position, out hit)) {
            if(hit.collider.transform != target) {
                _nodeState = NodeState.SUCCESS;
                return _nodeState;
            }
        }

        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
