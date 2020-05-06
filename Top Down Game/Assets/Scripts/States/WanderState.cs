/* Will move NPC's into random directions */
using System;
using UnityEngine;

public class WanderState : State
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;

    private EnemyAggro enemyAggro;
    private EnemyMovement enemyMovement;

    public WanderState(GameObject gameObject) : base(gameObject)
    {
        startingPosition = gameObject.transform.position;
        roamPosition = GetRoamingPosition();

        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        enemyMovement = gameObject.GetComponent<EnemyMovement>();

        enemyMovement.UpdateTarget(roamPosition);
    }

    public override Type Tick()
    {
        float reachedPointDistance = 1f;
        if(Vector3.Distance(gameObject.transform.position, roamPosition) < reachedPointDistance)
        {
            roamPosition = GetRoamingPosition();
            enemyMovement.UpdateTarget(roamPosition);
            
        }

        // if target is within range
        if(enemyAggro.isInRange)
        {
            return typeof(ChaseState);
        }

        return typeof(WanderState);
    }
    
    // Get a direction of where the unit will walk to
    private Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    // Get a position the unit will travel to
    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDirection() * UnityEngine.Random.Range(1f, 5f);
    }
}
