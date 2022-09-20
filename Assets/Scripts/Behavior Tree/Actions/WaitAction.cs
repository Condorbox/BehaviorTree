using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class WaitAction : Node
{
    private float duration;
    private float startTime;

    public WaitAction(float duration)
    {
        this.duration = duration;
        startTime = Time.time;
    }

    protected override void OnStart()
    {
        startTime = Time.time;
    }

    protected override NodeState OnUpdate()
    {
        if (Time.time - startTime > duration)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.RUNNING;
    }

    protected override void OnStop() { }
}
