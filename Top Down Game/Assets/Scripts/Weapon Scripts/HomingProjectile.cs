/* Will look for the closest enemy within its given radius. Once it has a target, it will attempt to home in on it and cause
 * damage on impact. If it can't find a target, it will just fly straight until it despawns
 */

using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile
{
    HomingProjectileStats homingProjectileStats;

    private List<Enemy> targets;

    private Enemy closestTarget;

    private float rotateSpeed, range;

    new void OnEnable()
    {
        base.OnEnable();

        // Need this cast for below references
        homingProjectileStats = (HomingProjectileStats)projectileStats;

        rotateSpeed = homingProjectileStats.RotateSpeed;
        range = homingProjectileStats.Range;

        targets = new List<Enemy>();
    }

    void FixedUpdate()
    {     
        FindTargets();

        // If no targets are found, fly straight
        if (targets.Count > 0)
        {
            FindClosestTarget();
            FireMissile();
        }
    }

    private void FindTargets()
    {
        // Find all colliders in range of the missile
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);

        // Loop through the targets and put all enemies in a list
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].tag == "Enemy")
            {
                targets.Add(hits[i].GetComponent<Enemy>());
            }
        }
    }

    // The missile will always prioritize the closest target to itself
    private void FindClosestTarget()
    {
        closestTarget = targets[0];

        float closestEnemyDistance = Mathf.Infinity;

        for (int i = 0; i < targets.Count; i++)
        {
            float distance = (transform.position - targets[i].transform.position).sqrMagnitude;

            if (closestEnemyDistance > distance)
            {
                closestEnemyDistance = distance;
                closestTarget = targets[i];
            }
        }
    }

    private void FireMissile()
    {
        Vector2 direction = (Vector2)closestTarget.transform.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * bulletVelocity;
    }
}
