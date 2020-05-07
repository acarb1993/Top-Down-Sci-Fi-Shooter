/* Chases player until in attack range */

using System;
using UnityEngine;

public class ChaseState : State
{
    private EnemyAggro enemyAggro;
    private EnemyMovement enemyMovement;
    private Vector3 startPosition;

    public ChaseState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        startPosition = enemyMovement.StartPosition;
    }

    public override Type Tick()
    {
        // Keep moving towards the player
        enemyMovement.TargetPosition = PlayerManager.Instance.Player.transform.position;

        if(!enemyAggro.isInRange)
        {
            enemyMovement.TargetPosition = startPosition;
            return typeof(WanderState);
        }

        return typeof(ChaseState);
    }
}
