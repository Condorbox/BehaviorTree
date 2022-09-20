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
                root.Update();
            }
        }

        protected abstract Node ConstructBehaviorTree();
    }

}
