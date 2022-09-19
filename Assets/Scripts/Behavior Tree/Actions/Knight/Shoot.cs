using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Shoot : Node
{
    private List<Weapon> weapons;
    private bool shakeCamera;
    private Transform transform;
    private Transform weaponTransform;

    public Shoot(List<Weapon> weapons, bool shakeCamera, Transform transform, Transform weaponTransform)
    {
        this.weapons = weapons;
        this.shakeCamera = shakeCamera;
        this.transform = transform;
        this.weaponTransform = weaponTransform;
    }

    public override NodeState Evaluate()
    {
        foreach (Weapon weapon in weapons)
        {
            var projectile = Object.Instantiate(weapon.projectilePrefab, weaponTransform.position, Quaternion.identity); //TODO PoolManager

            Vector2 force = new Vector2(weapon.horizontalForce * transform.localScale.x, weapon.verticalForce);
            if (projectile.TryGetComponent<Rigidbody2D>(out Rigidbody2D projectileRigidbody))
            {
                projectileRigidbody.AddForce(force);
            }

            if (shakeCamera)
            {
                //TODO Shake Camera
            }
        }

        _nodeState = NodeState.SUCCESS;
        return _nodeState;
    }
}
