using System;
using UnityEngine;

public class ChaseState : State
{
    private EnemyAggro enemyAggro;

    public ChaseState(GameObject gameObject) : base(gameObject)
    {
        enemyAggro = base.gameObject.GetComponent<EnemyAggro>();
    }

    public override Type Tick()
    {
        if(!enemyAggro.isInRange)
        {
            return typeof(WanderState);
        }

        return typeof(ChaseState);
    }
}
