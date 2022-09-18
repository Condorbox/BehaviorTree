using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Tree = BehaviorTree.Tree;

public class TryBTNodes : Tree
{
    protected override Node ConstructBehaviorTree()
    {
        DebugMessage debugMessageChange = new DebugMessage("Change");
        Repeater repeater = new Repeater(debugMessageChange, 3);
        Wait waitNode = new Wait(repeater, 3f);
        DebugMessage debugMessage = new DebugMessage(":D");

        return new RandomComposite(new List<Node> { waitNode, debugMessage });
    }
}
