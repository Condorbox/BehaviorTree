using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        protected Node root;
        [SerializeField] protected bool drawGizmos = false;

        protected virtual void Awake()
        {
            root = ConstructBehaviorTree();
        }

        protected virtual void Update()
        {
            if (root != null)
            {
                root.Update();
            }
        }

        protected abstract Node ConstructBehaviorTree();

        public static List<Node> GetChildren(Node parent)
        {
            List<Node> children = new List<Node>();

            if (parent is DecoratorNode decorator && decorator.child != null)
            {
                children.Add(decorator.child);
            }

            else if (parent is CompositeNode composite && composite.children != null)
            {
                return composite.children;
            }

            return children;
        }

        public static void Traverse(Node node, System.Action<Node> visiter)
        {
            if (node != null)
            {
                visiter.Invoke(node);
                var children = GetChildren(node);
                children.ForEach((n) => Traverse(n, visiter));
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (root == null || !drawGizmos)
            {
                return;
            }

            Tree.Traverse(root, (n) =>
            {
                n.OnDrawGizmos();
            });
        }
    }
}
