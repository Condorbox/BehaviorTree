using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Evaluate the node and returns always Success except if it's Running that returns Running

namespace BehaviorTree
{
    public class Succeeder : DecoratorNode
    {
        public Succeeder(Node node) : base(node) { }

        protected override void OnStart() { }

        protected override NodeState OnUpdate()
        {
            NodeState state = node.Update();
            if (state == NodeState.FAILURE)
            {
                return NodeState.SUCCESS;
            }
            return state;
        }

        protected override void OnStop() { }
    }
}
