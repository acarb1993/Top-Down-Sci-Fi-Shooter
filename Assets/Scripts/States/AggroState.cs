/* Chases the player when in range*/

using System;
using UnityEngine;

public class AggroState : State
{
    private EnemyMovement enemyMovement;
    private EnemyAggro enemyAggro;
    private Vector3 startPosition;

    public AggroState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        startPosition = enemyMovement.StartPosition;
    }

    public override Type Tick()
    {
        // Keep moving towards the player
        enemyMovement.TargetPosition = PlayerManager.Instance.Player.transform.position;
        float distanceToPlayer = PlayerManager.GetDistanceToPlayer(gameObject);

        // if in attack range, change to the attack state
        if(distanceToPlayer <= enemyAggro.AtackRange)
        {
            return typeof(AttackState);
        }

        if (distanceToPlayer >= enemyAggro.DisengageDist)
        {
            enemyMovement.TargetPosition = startPosition;
            return typeof(WanderState);
        }

        return typeof(AggroState);
    }
}
