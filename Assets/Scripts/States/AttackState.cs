using System;
using UnityEngine;

public class AttackState : State
{
    private AttackMove attackMove;
    private EnemyAggro enemyAggro;
    private float timer;

    public AttackState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = gameObject.GetComponent<EnemyAggro>();
        attackMove = gameObject.GetComponent<AttackMove>();
        timer = 0;
    }

    public override Type Tick()
    {
        // Keep track of the cooldown
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        // Attack the target
        if(timer <= 0)
        {
            attackMove.Attack(PlayerManager.Instance.Player);
            timer = attackMove.Cooldown;
        }

        float distanceToPlayer = PlayerManager.GetDistanceToPlayer(gameObject);
        // if no longer in range, go back to an aggro state
        if (distanceToPlayer >= enemyAggro.AtackRange)
        {
            return typeof(AggroState);
        }

        return typeof(AttackState);
    }
}
