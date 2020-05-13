using System.Collections.Generic;
using System;

public class Drone : Enemy
{
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
            { typeof(AggroState), new AggroState(gameObject) }
        };

        stateMachine.InitalizeStates(states);
    }
}
