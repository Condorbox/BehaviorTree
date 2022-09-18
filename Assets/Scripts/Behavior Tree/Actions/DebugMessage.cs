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

    public override NodeState Evaluate()
    {
        Debug.Log(message);
        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
