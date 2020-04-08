/* Calculates the distance from the enemy to the player, this useful if the enemy needs to chase the player, 
 * check attack distances, etc. This way you don't need to calculate the distance in multiple scripts.
 */

using UnityEngine;

public class DistanceToPlayer : MonoBehaviour
{
    private Transform playerPos;

    public float playerDistance { get; private set; }

    void Start()
    {
        playerPos = PlayerManager.Instance.Player.transform;
    }

    void Update()
    {
        playerDistance = Vector2.Distance(transform.position, playerPos.position);
    }
}
