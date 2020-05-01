using System;
using UnityEngine;

public class AttackState : State
{
    public AttackState(GameObject gameObject) : base(gameObject)
    {

    }

    public override Type Tick()
    {
        return typeof(AttackState);
    }
}
