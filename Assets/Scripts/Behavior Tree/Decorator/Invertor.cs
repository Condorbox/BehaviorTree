using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Invert the state Success -> Failure; Running -> Running and returns it

namespace BehaviorTree
{
    public class Invertor : DecoratorNode
    {
        public Invertor(Node node) : base(node) { }

        public override NodeState Evaluate()
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    break;

                case NodeState.SUCCESS:
                    _nodeState = NodeState.FAILURE;
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

