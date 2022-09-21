using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class InterruptSelector : Selector
    {
        private int current = 0;
        InterruptSelector(List<Node> nodes) : base(nodes) { }

        protected override void OnStart()
        {
            current = 0;
        }
        protected override NodeState OnUpdate()
        {
            int previous = current;
            current = 0;
            NodeState status = base.OnUpdate();
            if (previous != current)
            {
                if (nodes[previous].nodeState == NodeState.RUNNING)
                {
                    nodes[previous].Abort();
                }
            }

            return status;
        }
    }
}
