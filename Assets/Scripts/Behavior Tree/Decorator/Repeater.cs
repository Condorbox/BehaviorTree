using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Repeat the node n numbers of times and returns Success

namespace BehaviorTree
{
    public class Repeater : DecoratorNode
    {
        private int timesToRepeat;

        public Repeater(Node node, int timesToRepeat) : base(node)
        {
            this.timesToRepeat = timesToRepeat;
        }

        protected override void OnStart() { }

        protected override NodeState OnUpdate()
        {
            for (int i = 0; i < timesToRepeat; i++)
            {
                node.Update();
            }

            return NodeState.SUCCESS;
        }

        protected override void OnStop() { }
    }
}