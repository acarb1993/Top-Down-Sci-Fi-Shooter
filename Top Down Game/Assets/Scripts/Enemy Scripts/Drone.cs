using System.Collections.Generic;
using System;
using UnityEngine;

public class Drone : Enemy
{
    [SerializeField] private Transform wanderPoints;

    private StateMachine stateMachine;
    private Dictionary<Type, State> states;

    private void Awake()
    {
        InitalizeStates();
    }

    protected override void Start() => base.Start();

    protected override void InitalizeStates()
    {
        // Needs to have this component for AI behavior
        stateMachine = GetComponent<StateMachine>();

        states = new Dictionary<Type, State>()
        {
            { typeof(WanderState), new WanderState(gameObject) },
            { typeof(ChaseState), new ChaseState(gameObject) }
        };

        stateMachine.InitalizeStates(states);
    }
}
