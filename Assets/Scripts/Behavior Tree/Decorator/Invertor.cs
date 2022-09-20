using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Invert the state Success -> Failure; Running -> Running and returns it

namespace BehaviorTree
{
    public class Invertor : DecoratorNode
    {
        public Invertor(Node node) : base(node) { }

        protected override void OnStart() { }

        protected override NodeState OnUpdate()
        {
            switch (node.Update())
            {
                case NodeState.RUNNING:
                    return NodeState.RUNNING;

                case NodeState.SUCCESS:
                    return NodeState.FAILURE;

                case NodeState.FAILURE:
                    return NodeState.SUCCESS;

                default:
                    UnityEngine.Debug.LogWarning($"<color=yellow>Error: state {node.nodeState} not defined</color>");
                    break;
            }

            return NodeState.FAILURE;
        }

        protected override void OnStop() { }
    }
}

