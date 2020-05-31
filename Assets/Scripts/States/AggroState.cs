using System;
using UnityEngine;

public class AggroState : State
{
    private EnemyMovement enemyMovement;
    private EnemyAggro enemyAggro;
    private Vector3 startPosition;
    private AttackMove attackMove;

    private float timer;

    public AggroState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        startPosition = enemyMovement.StartPosition;
        attackMove = gameObject.GetComponent<AttackMove>();
        timer = 0;
    }

    public override Type Tick()
    {
        // Keep track of the cooldown
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        // Keep moving towards the player
        enemyMovement.TargetPosition = PlayerManager.Instance.Player.transform.position;
        float distanceToPlayer = PlayerManager.GetDistanceToPlayer(gameObject);

        // if in attack range
        if(distanceToPlayer <= enemyAggro.AtackRange && timer <= 0)
        {
            // Attack the target
            attackMove.Attack(PlayerManager.Instance.Player);
            timer = attackMove.Cooldown;
        }

        if (distanceToPlayer >= enemyAggro.DisengageDist)
        {
            enemyMovement.TargetPosition = startPosition;
            timer = 0;
            return typeof(WanderState);
        }

        return typeof(AggroState);
    }
}
