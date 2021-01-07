/* Chases the player when in range*/

using System;
using UnityEngine;

public class AggroState : State
{
    private EnemyAggro enemyAggro;
    private EnemyMovement enemyMovement;
    private FaceTarget faceTarget;
    private Vector3 startPosition;

    public AggroState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        faceTarget = gameObject.GetComponent<FaceTarget>();
        startPosition = enemyMovement.StartPosition;
    }

    public override Type Tick()
    {
        // Keep moving towards the player
        updateTargets();
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

    private void updateTargets()
    {
        enemyMovement.TargetPosition = PlayerManager.Instance.Player.transform.position;
        faceTarget.Target = PlayerManager.Instance.Player.transform.position;
    }
}
