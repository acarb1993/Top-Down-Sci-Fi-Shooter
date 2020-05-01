/* Will move NPC's into random directions or perhaps along a path */
using System;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    private FloatVariable droneSpeed;
    private EnemyAggro aggro;

    // List of points where the AI will travel
    private List<Transform> wanderPoints;
    // The current point the AI is travelling to
    private Transform pointToTravel;
    private int numberOfPoints;
    private float waitTime, timer;

    public WanderState(GameObject gameObject, Transform wp, FloatVariable ds) : base(gameObject)
    {
        wanderPoints = new List<Transform>();
        droneSpeed = ds;

        aggro = referencedObject.GetComponent<EnemyAggro>();

        // Get each point from the passed in wp gameObject. These are the wander points the AI can go to
        foreach(Transform point in wp.transform)
        {
            wanderPoints.Add(point);
        }

        numberOfPoints = wanderPoints.Count;

        waitTime = 5;
        timer = waitTime;
    }

    public override Type Tick()
    {
        // if target is within range
        if(aggro.isInRange)
        {
            return typeof(ChaseState);
        }

        if (timer >= waitTime)
        {
            int pointIndex = UnityEngine.Random.Range(0, numberOfPoints);

            pointToTravel = wanderPoints[pointIndex];

            timer = 0;
        }
       
        timer += Time.deltaTime;

        return typeof(WanderState);
    }

    public override void FixedTick()
    {
        referencedObject.transform.position = Vector2.MoveTowards(
               referencedObject.transform.position,
               pointToTravel.position,
               droneSpeed.RuntimeValue * Time.deltaTime);
    }
}
