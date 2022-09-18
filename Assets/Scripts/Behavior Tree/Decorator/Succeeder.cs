using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Evaluate the node and returns always Success except if it's Running that returns Running

namespace BehaviorTree
{
    public class Succeeder : DecoratorNode
    {
        public Succeeder(Node node) : base(node) { }

        public override NodeState Evaluate()
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    break;

                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    break;

                case NodeState.FAILURE:
                    _nodeState = NodeState.SUCCESS;
                    break;

                default:
                    UnityEngine.Debug.LogWarning($"<color=yellow>Error: state {node.nodeState} not defined</color>");
                    break;
            }

            return _nodeState;
        }
    }
}
