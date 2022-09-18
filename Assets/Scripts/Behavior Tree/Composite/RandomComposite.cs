using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Select a random node and returns its nodeState

namespace BehaviorTree
{
    public class RandomComposite : CompositeNode
    {
        public RandomComposite(List<Node> nodes) : base(nodes) { }

        public override NodeState Evaluate()
        {
            int randomNumber = Random.Range(0, nodes.Count);

            _nodeState = nodes[randomNumber].Evaluate();

            return _nodeState;
        }
    }
}
