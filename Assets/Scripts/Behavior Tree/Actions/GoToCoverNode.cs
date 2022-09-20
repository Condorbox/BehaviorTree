using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class GoToCoverNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai;

    public GoToCoverNode(NavMeshAgent agent, EnemyAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    protected override void OnStart() { }

    protected override NodeState OnUpdate()
    {
        Transform coverSpot = ai.GetBestCoverSpot();
        if (coverSpot == null)
        {
            return NodeState.FAILURE;
        }

        ai.SetColor(Color.blue);
        float distance = Vector3.Distance(coverSpot.position, agent.transform.position);
        if (distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(coverSpot.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }

    protected override void OnStop() { }
}
