using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Repeats Until node Fails, always returns Success WARNING IN THE USE can always evaluate and will explode :P

namespace BehaviorTree
{
    public class RepeatUntilFail : DecoratorNode
    {
        public RepeatUntilFail(Node node) : base(node) { }

        public override NodeState Evaluate()
        {
            NodeState childState = node.Evaluate();
            while (childState != NodeState.FAILURE)
            {
                childState = node.Evaluate();
            }

            _nodeState = NodeState.SUCCESS;
            return _nodeState;
        }
    }
}
