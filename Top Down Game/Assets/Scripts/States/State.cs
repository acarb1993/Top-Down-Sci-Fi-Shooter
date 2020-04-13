using System;
using UnityEngine;

public abstract class State
{
    protected GameObject character;
    protected Rigidbody2D rb;

    public State(GameObject gameObject)
    {
        character = gameObject;
        rb = character.GetComponent<Rigidbody2D>();
    }

    // Tick should be called in Update()
    public abstract Type Tick();
}
