/* Gives any character in the game Health, allows the character to take damage and be
 * hit by attacks and abilities.
 */

using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField]
    private float maxHealth = 100;

    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float CurrentHealth { get; set; }

    // Have Awake() run so the health is always initialized for UI elements
    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0) { Kill(); }
    }

    public void RestoreHealth(float restore)
    {
        CurrentHealth += restore;

        if (CurrentHealth > maxHealth) { CurrentHealth = maxHealth; }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
