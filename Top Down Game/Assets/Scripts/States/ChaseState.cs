using System;
using UnityEngine;

public class ChaseState : State
{
    private GameObject chaseTarget;
    private FloatVariable droneSpeed;
    private Vector2 movement;
    private EnemyAggro enemyAggro;

    public ChaseState(GameObject gameObject, FloatVariable ds) : base(gameObject)
    {
        // TODO may want to have other targets besides the player
        droneSpeed = ds;

        enemyAggro = character.GetComponent<EnemyAggro>();
        enemyAggro.OnPlayerInRange += AssignTarget;
    }

    public override Type Tick()
    {
        if(!enemyAggro.isInRange)
        {
            return typeof(WanderState);
        }

        // Chase the target
        Vector2 targetDirection = chaseTarget.transform.position - character.transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        targetDirection.Normalize();
        movement = targetDirection;
        Chase(movement);

        return typeof(ChaseState);
    }

    private void Chase(Vector2 direction)
    {
        Vector2 position = character.transform.position;
        rb.MovePosition(position + (direction * droneSpeed.RuntimeValue * Time.deltaTime));
    }

    // If the player is in range from EnemyAggro the event will fire assigning the target
    // DO NOT initalize target in constructor. It will fire before Awake() causing a null exception
    private void AssignTarget()
    {
        chaseTarget = PlayerManager.Instance.Player;
        enemyAggro.OnPlayerInRange -= AssignTarget;
    }
}
