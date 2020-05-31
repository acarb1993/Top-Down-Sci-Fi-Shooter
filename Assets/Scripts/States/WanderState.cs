/* Will move NPC's into random directions */
using System;
using UnityEngine;

public class WanderState : State
{
    private EnemyAggro enemyAggro;
    private EnemyMovement enemyMovement;

    private Vector3 startingPosition;
    private Vector3 roamPosition;

    public WanderState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        enemyMovement = gameObject.GetComponent<EnemyMovement>();

        startingPosition = enemyMovement.StartPosition;
        roamPosition = GetRoamingPosition();

        enemyMovement.TargetPosition = roamPosition;
    }

    public override Type Tick()
    {
        float reachedPointDistance = 1f;
        float distanceToTarget = Vector3.Distance(gameObject.transform.position, enemyMovement.TargetPosition);
        float distanceToPlayer = PlayerManager.GetDistanceToPlayer(gameObject);

        if(distanceToTarget < reachedPointDistance)
        {
            roamPosition = GetRoamingPosition();
            enemyMovement.TargetPosition = roamPosition;
        }

        // if target is within range
        if(enemyAggro.AggroDistance >= distanceToPlayer)
        {
            return typeof(AggroState);
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
