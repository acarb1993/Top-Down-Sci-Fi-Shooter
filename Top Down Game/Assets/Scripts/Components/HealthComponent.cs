/* Gives any character in the game Health, allows the character to take damage and be
 * hit by attacks and abilities.
 */

using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable, IKillable
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0) { Kill(); }
    }

    public void RestoreHealth(float restore)
    {
        CurrentHealth += restore;

        if (CurrentHealth > MaxHealth) { CurrentHealth = MaxHealth; }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
