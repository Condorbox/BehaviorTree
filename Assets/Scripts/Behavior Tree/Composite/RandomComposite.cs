using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Select a random node and returns its nodeState, re-selects the node when Success or Failure

namespace BehaviorTree
{
    public class RandomComposite : CompositeNode
    {
        private int randomNumber;
        public RandomComposite(List<Node> nodes) : base(nodes)
        {
            randomNumber = Random.Range(0, nodes.Count);
        }

        protected override void OnStart()
        {
            randomNumber = Random.Range(0, nodes.Count);
        }

        protected override NodeState OnUpdate()
        {
            return nodes[randomNumber].Update();
        }

        protected override void OnStop() { }
    }
}
