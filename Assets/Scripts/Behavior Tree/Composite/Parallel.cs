using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviorTree;

namespace BehaviorTree
{
    public class Parallel : CompositeNode
    {
        List<NodeState> nodesLeftToExecute = new List<NodeState>();
        public Parallel(List<Node> nodes) : base(nodes) { }
        protected override void OnStart()
        {
            nodesLeftToExecute.Clear();
            nodes.ForEach(a =>
            {
                nodesLeftToExecute.Add(NodeState.RUNNING);
            });
        }

        protected override NodeState OnUpdate()
        {
            bool stillRunning = false;
            for (int i = 0; i < nodesLeftToExecute.Count(); i++)
            {
                if (nodesLeftToExecute[i] == NodeState.RUNNING)
                {
                    NodeState status = nodes[i].Update();
                    if (status == NodeState.FAILURE)
                    {
                        AbortRunningNodes();
                        return NodeState.FAILURE;
                    }

                    if (status == NodeState.RUNNING)
                    {
                        stillRunning = true;
                    }

                    nodesLeftToExecute[i] = status;
                }
            }

            return stillRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        }

        private void AbortRunningNodes()
        {
            for (int i = 0; i < nodesLeftToExecute.Count(); i++)
            {
                if (nodesLeftToExecute[i] == NodeState.RUNNING)
                {
                    nodes[i].Abort();
                }
            }
        }

        protected override void OnStop() { }
    }
}
