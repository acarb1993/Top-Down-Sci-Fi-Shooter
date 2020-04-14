/* Will move NPC's into random directions or perhaps along a path */

using System;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    private List<Transform> wanderPoints;
    private Transform pointToTravel;
    private int numberOfPoints;
    private float waitTime, timer;

    public WanderState(GameObject gameObject, Transform wp) : base(gameObject)
    {
        wanderPoints = new List<Transform>();

        // Get each point from the passed in wp gameObject. These are the wander points the AI can go to
        foreach(Transform point in wp.transform)
        {
            wanderPoints.Add(point);
        }

        numberOfPoints = wanderPoints.Count;

        waitTime = 5;
        timer = 5;
    }

    public override Type Tick()
    {
        if(timer >= waitTime)
        {
            // This is what point the AI will travel to
            pointToTravel = wanderPoints[UnityEngine.Random.Range(0, numberOfPoints)];

            timer = 0;
        }

        // Will move towards the random target that is picked
        // TODO take away hard coding of speed
        character.transform.position = Vector2.MoveTowards(
                character.transform.position,
                pointToTravel.position,
                2 * Time.deltaTime);

        timer += Time.deltaTime;

        return typeof(WanderState);
    }
}
