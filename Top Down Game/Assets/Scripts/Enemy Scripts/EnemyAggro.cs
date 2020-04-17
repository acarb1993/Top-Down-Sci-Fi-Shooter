/* Responsible for checking how far the player is from the enemy */
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private float aggroDist = 2;
    [SerializeField] private float disengageDist = 10;

    private GameObject player;

    public delegate void InRange();
    public event InRange OnPlayerInRange;

    public bool isInRange = false;

    void Start()
    {
        player = PlayerManager.Instance.Player;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(distanceToPlayer <= aggroDist)
        {
            isInRange = true;
            OnPlayerInRange?.Invoke();
        }

        if(isInRange)
        {
            if(distanceToPlayer > disengageDist)
            {
                isInRange = false;
            }
        }
    }
}
