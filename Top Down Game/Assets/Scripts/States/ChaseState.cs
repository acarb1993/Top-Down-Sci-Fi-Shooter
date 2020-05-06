/* Chases player until in attack range */

using System;
using UnityEngine;

public class ChaseState : State
{
    private EnemyAggro enemyAggro;
    private EnemyMovement enemyMovement;

    public ChaseState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
    }

    public override Type Tick()
    {
        // Keep moving towards the player
        enemyMovement.UpdateTarget(PlayerManager.Instance.Player.transform.position);

        if(!enemyAggro.isInRange)
        {
            // TODO enemy won't move after going back to Wander
            return typeof(WanderState);
        }

        return typeof(ChaseState);
    }
}
