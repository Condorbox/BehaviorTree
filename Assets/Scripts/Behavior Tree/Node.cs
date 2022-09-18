using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{

    [System.Serializable]
    public abstract class Node
    {
        protected Node parent;
        protected NodeState _nodeState;
        public NodeState nodeState { get { return _nodeState; } }
        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }

        public abstract NodeState Evaluate();

        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (dataContext.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                {
                    return value;
                }
                node = node.parent;
            }

            return value;
        }

        public bool ClearData(string key)
        {
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                {
                    return true;
                }
                node = node.parent;
            }

            return false;
        }

        public void SetParent(Node node)
        {
            parent = node;
        }

        public Node GetParent() => parent;
    }

    public enum NodeState
    {
        SUCCESS,
        RUNNING,
        FAILURE
    }
}

