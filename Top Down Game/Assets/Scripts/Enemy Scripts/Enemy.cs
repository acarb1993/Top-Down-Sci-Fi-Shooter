/* Gives objects the Enemy class this will help distinguish targets for the enemies and the player to
 * avoid enemies hitting each other and letting the player hit these targets with abilities
 */

using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyStats enemyStats;

    private HealthComponent healthComponent;

    void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.MaxHealth = enemyStats.StartingHealth;
    }

    private void Start()
    {
        // Adds an enemy to a singleton on the Game Manager object in the scene
        EnemyManager.Instance.AddEnemy(this);
    }

    void Update()
    {

    }
}
