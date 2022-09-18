using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        protected Node root;

        protected virtual void Awake()
        {
            root = ConstructBehaviorTree();
        }

        protected virtual void Update()
        {
            if (root != null)
            {
                root.Evaluate();
            }
        }

        protected abstract Node ConstructBehaviorTree();
    }

}
