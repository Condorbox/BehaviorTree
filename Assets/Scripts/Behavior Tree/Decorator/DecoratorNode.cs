using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class DecoratorNode : Node
    {
        protected Node node;

        public DecoratorNode(Node node)
        {
            node.SetParent(this);
            this.node = node;
        }
    }
}