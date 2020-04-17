/* Gives objects the Enemy class this will help distinguish targets for the enemies and the player to
 * avoid enemies hitting each other and letting the player hit these targets with abilities
 */

using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;

    private HealthComponent healthComponent;

    protected virtual void Start()
    {
        // Adds an enemy to a singleton on the Game Manager object in the scene
        EnemyManager.Instance.AddEnemy(this);
    }

    // Every enemy has an AI. This makes sure each enemy has states it should be initalized with.
    protected abstract void InitalizeStates();
}
