// Base class for all behavior states in the game
using System;
using UnityEngine;

public abstract class State
{
    protected GameObject gameObject;

    // Takes in the object that this state is controlling
    public State(GameObject go)
    {
        gameObject = go;
    }

    /* Tick should be called in Update() this is what the object is doing in the current state
     * this also returns either the state it's already in or another state based on conditions within that state */
    public abstract Type Tick();
}
