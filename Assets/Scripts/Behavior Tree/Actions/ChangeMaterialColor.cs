using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class ChangeMaterialColor : Node
{
    private Material material;

    public ChangeMaterialColor(Material material) : base()
    {
        this.material = material;
    }

    public override NodeState Evaluate()
    {
        material.color = Random.ColorHSV();
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
