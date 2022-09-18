using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class GoToCoverNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai;

    public GoToCoverNode(NavMeshAgent agent, EnemyAI ai) {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate() {
        Transform coverSpot = ai.GetBestCoverSpot();
        if (coverSpot == null) {
            _nodeState = NodeState.FAILURE;
            return _nodeState;
        }

        ai.SetColor(Color.blue);
        float distance = Vector3.Distance(coverSpot.position, agent.transform.position);
        if(distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(coverSpot.position);
            _nodeState = NodeState.RUNNING;
            return _nodeState;
        }
        else
        {
            agent.isStopped = true;
            _nodeState = NodeState.SUCCESS;
            return _nodeState;
        }
    }
}
