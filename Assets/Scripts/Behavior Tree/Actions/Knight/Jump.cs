using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using DG.Tweening;
using UnityEngine;

public class Jump : Node
{
    private float horizontalForce;  //3
    private float jumpForce;        //20
    private float buildupTime;      //.5 
    private float jumpTime;         //1.3
    private bool shakeCameraOnLanding;
    private Animator animator;

    private bool jumped = false;
    private Transform playerTransform;
    private Transform transform;
    private Rigidbody2D rb;

    private bool hasLanded;

    private Tween buildupTween;
    private Tween jumpTween;

    public Jump(float horizontalForce, float jumpForce, float buildupTime, float jumpTime, bool shakeCameraOnLanding, Animator animator, Transform player, Transform transform, Rigidbody2D rb)
    {
        this.horizontalForce = horizontalForce;
        this.jumpForce = jumpForce;
        this.buildupTime = buildupTime;
        this.jumpTime = jumpTime;
        this.shakeCameraOnLanding = shakeCameraOnLanding;
        this.animator = animator;
        this.jumped = false;
        this.playerTransform = player;
        this.transform = transform;
        this.rb = rb;
    }

    public override NodeState Evaluate()
    {
        if (!jumped)
        {
            buildupTween = DOVirtual.DelayedCall(buildupTime, StartJump, false);
            //animator.SetTrigger("Jump");
            jumped = true;
        }

        _nodeState = hasLanded ? NodeState.SUCCESS : NodeState.RUNNING;

        if (_nodeState == NodeState.SUCCESS)
        {
            jumped = false;
            buildupTween?.Kill();
            jumpTween?.Kill();
            hasLanded = false;
        }

        return _nodeState;
    }

    private void StartJump()
    {
        var direction = playerTransform.position.x < transform.position.x ? -1 : 1;
        rb.AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

        jumpTween = DOVirtual.DelayedCall(jumpTime, () =>
        {
            hasLanded = true;
            if (shakeCameraOnLanding)
            {
                //TODO Shake Camera
            }
        }, false);
    }
}
