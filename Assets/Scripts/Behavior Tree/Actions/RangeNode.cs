using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class RangeNode : Node
{
    private float range;
    private Transform target;
    private Transform origin;
    private Color color;

    public RangeNode(float range, Transform target, Transform origin)
    {
        this.range = range;
        this.target = target;
        this.origin = origin;
        color = Color.red;
    }

    public RangeNode(float range, Transform target, Transform origin, Color color)
    {
        this.range = range;
        this.target = target;
        this.origin = origin;
        this.color = color;
    }

    protected override void OnStart() { }

    protected override NodeState OnUpdate()
    {
        float distance = Vector3.Distance(target.position, origin.position);
        return distance <= range ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    protected override void OnStop() { }

    public override void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(origin.position, range);
    }
}
