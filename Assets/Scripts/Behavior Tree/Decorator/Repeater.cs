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

        public override NodeState Evaluate()
        {
            for (int i = 0; i < timesToRepeat; i++)
            {
                node.Evaluate();
            }

            _nodeState = NodeState.SUCCESS;
            return _nodeState;
        }
    }
}