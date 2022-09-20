using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class DebugMessage : Node
{
    private string message;
    public DebugMessage(string message) : base()
    {
        this.message = message;
    }

    protected override void OnStart() { }

    protected override NodeState OnUpdate()
    {
        Debug.Log($"{message}");
        return NodeState.SUCCESS;
    }

    protected override void OnStop() { }
}
