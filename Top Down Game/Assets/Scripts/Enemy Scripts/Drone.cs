using System.Collections.Generic;
using System;
using UnityEngine;

public class Drone : Enemy
{

    [SerializeField] private Transform wanderPoints;

    private StateMachine stateMachine;
    private Dictionary<Type, State> states;

    protected override void Awake()
    {
        base.Awake();
        InitalizeStates();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void InitalizeStates()
    {
        // Needs to have this component for AI behavior
        stateMachine = GetComponent<StateMachine>();

        states = new Dictionary<Type, State>()
        {
            { typeof(WanderState), new WanderState(gameObject, wanderPoints) }
        };

        stateMachine.InitalizeStates(states);
    }
}
