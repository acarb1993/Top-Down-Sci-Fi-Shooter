/* Will move NPC's into random directions or perhaps along a path */

using System;
using UnityEngine;

public class WanderState : State
{
    public WanderState(GameObject gameObject) : base(gameObject)
    {

    }

    public override Type Tick()
    {
        // Needs to move in random directions
        float speed = 2f;
        Vector2 movement = new Vector2(-1, 0);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        return typeof(WanderState);
    }
}
