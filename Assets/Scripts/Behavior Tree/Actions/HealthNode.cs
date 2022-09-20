using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class HealthNode : Node
{
    private EnemyAI ai;
    private float threshold;

    public HealthNode(EnemyAI ai, float threshold)
    {
        this.ai = ai;
        this.threshold = threshold;
    }

    protected override void OnStart() { }

    protected override NodeState OnUpdate()
    {
        return ai.GetCurrentHealth() <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    protected override void OnStop() { }
}
