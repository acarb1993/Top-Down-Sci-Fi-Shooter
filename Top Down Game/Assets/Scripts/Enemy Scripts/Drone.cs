using System.Collections.Generic;
using System;

public class Drone : Enemy
{
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

    void Update()
    {
        //stateMachine.TickState();
    }

    private void InitalizeStates()
    {
        // Needs to have this component for AI behavior
        stateMachine = GetComponent<StateMachine>();

        states = new Dictionary<Type, State>()
        {
            { typeof(WanderState), new WanderState(gameObject) }
        };

        stateMachine.InitalizeStates(states);
    }
}
