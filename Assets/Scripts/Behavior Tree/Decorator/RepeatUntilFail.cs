using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Repeats Until node Fails, always returns Success WARNING IN THE USE can always evaluate and will explode :P

namespace BehaviorTree
{
    public class RepeatUntilFail : DecoratorNode
    {
        public RepeatUntilFail(Node node) : base(node) { }

        protected override void OnStart() { }

        protected override NodeState OnUpdate()
        {
            NodeState childState;
            do
            {
                childState = node.Update();
            } while (childState != NodeState.FAILURE);

            return NodeState.SUCCESS;
        }

        protected override void OnStop() { }
    }
}
