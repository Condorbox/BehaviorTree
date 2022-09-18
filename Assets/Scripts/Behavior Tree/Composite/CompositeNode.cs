using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public abstract class CompositeNode : Node
    {
        protected List<Node> nodes = new List<Node>();

        public CompositeNode(List<Node> children)
        {
            foreach (Node child in children)
            {
                Attach(child);
            }
        }

        private void Attach(Node node)
        {
            node.SetParent(this);
            nodes.Add(node);
        }
    }
}

