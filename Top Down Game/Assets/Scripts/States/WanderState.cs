/* Will move NPC's into random directions or perhaps along a path */
using System;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    // How long to wait before traveling to a different point
    [SerializeField] private float waitTime = 5;

    private EnemyAggro aggro;
    private EnemyMovement enemyMovement;

    // List of points where the AI will travel
    private List<Transform> wanderPoints;
    // The current point the AI is travelling to
    private Transform pointToTravel;
    private int numberOfPoints;
    private float timer;

    public WanderState(GameObject gameObject, Transform wp, FloatVariable ds) : base(gameObject)
    {
        wanderPoints = new List<Transform>();

        aggro = base.gameObject.GetComponent<EnemyAggro>();
        enemyMovement = base.gameObject.GetComponent<EnemyMovement>();

        // Get each point from the passed in wp gameObject. These are the wander points the AI can go to
        foreach(Transform point in wp.transform)
        {
            wanderPoints.Add(point);
        }

        numberOfPoints = wanderPoints.Count;

        timer = waitTime;
    }

    public override Type Tick()
    {
        // if target is within range
        if(aggro.isInRange)
        {
            enemyMovement.UpdateTarget(PlayerManager.Instance.Player.transform);
            return typeof(ChaseState);
        }

        if (timer >= waitTime)
        {
            // Select a random point to move to
            int pointIndex = UnityEngine.Random.Range(0, numberOfPoints);

            pointToTravel = wanderPoints[pointIndex];

            enemyMovement.UpdateTarget(pointToTravel);

            timer = 0;
        }
       
        timer += Time.deltaTime;

        return typeof(WanderState);
    }
}
