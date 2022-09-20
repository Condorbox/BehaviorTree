using System.Collections;
using System.Collections.Generic;

//Execute all the children until one of them is Success/Running and returns the state
//If all the children are Failure return failure

namespace BehaviorTree
{
    public class Selector : CompositeNode
    {
        public Selector(List<Node> nodes) : base(nodes) { }

        protected override void OnStart() { }

        protected override NodeState OnUpdate()
        {
            foreach (Node node in nodes)
            {
                switch (node.Update())
                {
                    case NodeState.RUNNING:
                        return NodeState.RUNNING;

                    case NodeState.SUCCESS:
                        return NodeState.SUCCESS;

                    case NodeState.FAILURE:
                        continue;

                    default:
                        UnityEngine.Debug.LogWarning($"<color=yellow>Error: state {node.nodeState} not defined</color>");
                        break;
                }
            }

            return NodeState.FAILURE;
        }
        protected override void OnStop() { }
    }
}