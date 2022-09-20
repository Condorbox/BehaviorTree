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

        protected override void OnStart()
        {
            counter = timeToWait;
        }


        protected override NodeState OnUpdate()
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                return node.Update();
            }

            return NodeState.RUNNING;
        }
        protected override void OnStop() { }
    }
}
