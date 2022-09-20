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

    protected override void OnStart() { }

    protected override NodeState OnUpdate()
    {
        material.color = Random.ColorHSV();
        return NodeState.SUCCESS;
    }

    protected override void OnStop() { }
}
