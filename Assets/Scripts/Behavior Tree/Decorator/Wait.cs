using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wait x seconds returning RUNNING and then returns what child.Evaluate() returns

namespace BehaviorTree
{
    public class Wait : DecoratorNode
    {
        private float timeToWait;
        private float counter;
        public Wait(Node node, float timeToWait) : base(node)
        {
            this.timeToWait = timeToWait;
            counter = this.timeToWait;
        }

        public override NodeState Evaluate()
        {
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                counter = timeToWait;
                _nodeState = node.Evaluate();
                return _nodeState;
            }

            _nodeState = NodeState.RUNNING;
            return _nodeState;
        }
    }
}
