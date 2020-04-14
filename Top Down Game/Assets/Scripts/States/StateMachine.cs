/* Controls the AI of the game as it shifts to different states based on certain conditions */

using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // States will be looked up by their class type, all should be inherited from State
    private Dictionary<Type, State> availableStates;
    public State CurrentState { get; private set; }

    private void Update()
    {
        // Sets state to first available state by default
        if(CurrentState == null)
        {
            CurrentState = availableStates.Values.First();
        }

        // Returns the type of state we want to switch to
        // ?. makes sure CurrentState isn't null anymore
        Type nextState = CurrentState?.Tick();

        if(nextState != null &&
            nextState != CurrentState?.GetType() )
        {
            SwitchStates(nextState);
        }
    }

    // Initalizes states in another script for use
    public void InitalizeStates(Dictionary<Type, State> states)
    {
        availableStates = states;
    }

    private void SwitchStates(Type nextState)
    {
        CurrentState = availableStates[nextState];
    }
}
