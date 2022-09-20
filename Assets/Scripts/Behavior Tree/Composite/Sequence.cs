using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Execute all the children until one is failure and returns Failure
//Returns Success or Running if all the children are Success/Running and returns Running if one or more is Running, Success if not

namespace BehaviorTree
{
    public class Sequence : CompositeNode
    {
        public Sequence(List<Node> nodes) : base(nodes) { }

        protected override void OnStop() { }

        protected override NodeState OnUpdate()
        {
            bool isAnyNodeRunning = false;
            foreach (Node node in nodes)
            {
                switch (node.Update())
                {
                    case NodeState.RUNNING:         //TODO Maybe return NodeState.RUNNING
                        isAnyNodeRunning = true;
                        continue;

                    case NodeState.SUCCESS:
                        continue;

                    case NodeState.FAILURE:
                        _nodeState = NodeState.FAILURE;
                        return _nodeState;

                    default:
                        UnityEngine.Debug.LogWarning($"<color=yellow>Error: state {node.nodeState} not defined</color>");
                        break;
                }
            }

            return isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        }

        protected override void OnStart() { }
    }
}
