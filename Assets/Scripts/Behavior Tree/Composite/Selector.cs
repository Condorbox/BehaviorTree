using System.Collections;
using System.Collections.Generic;

//Execute all the children until one of them is Success/Running and returns the state
//If all the children are Failure return failure

namespace BehaviorTree
{
    public class Selector : CompositeNode
    {
        public Selector(List<Node> nodes) : base(nodes) { }

        public override NodeState Evaluate()
        {
            foreach (Node node in nodes)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        _nodeState = NodeState.RUNNING;
                        return _nodeState;

                    case NodeState.SUCCESS:
                        _nodeState = NodeState.SUCCESS;
                        return _nodeState;

                    case NodeState.FAILURE:
                        continue;

                    default:
                        UnityEngine.Debug.LogWarning($"<color=yellow>Error: state {node.nodeState} not defined</color>");
                        break;
                }
            }

            _nodeState = NodeState.FAILURE;
            return _nodeState;
        }
    }
}