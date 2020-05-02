/* Responsible for checking how far the player is from the enemy */
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private float aggroDist = 2;
    [SerializeField] private float disengageDist = 10;

    private GameObject player;

    public bool isInRange = false;

    void Start()
    {
        player = PlayerManager.Instance.Player;
    }

    void Update()
    {
        // Check to see if player is in range
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Checks if the player is in range
        if(distanceToPlayer <= aggroDist)
        {
            isInRange = true;
        }

        // If the player is in range, checks if the player runs far enough away is disengage
        if(isInRange)
        {
            if(distanceToPlayer > disengageDist)
            {
                isInRange = false;
            }
        }
    }
}
