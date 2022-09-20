using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Failureer : DecoratorNode
    {
        public Failureer(Node node) : base(node) { }

        protected override void OnStart() { }
        protected override NodeState OnUpdate()
        {
            NodeState state = node.Update();
            if (state == NodeState.SUCCESS)
            {
                return NodeState.FAILURE;
            }
            return state;
        }

        protected override void OnStop() { }
    }
}

