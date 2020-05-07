/* Gives any character in the game Health, allows the character to take damage and be
 * hit by attacks and abilities.
 */
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] private FloatVariable floatVariable;
    [SerializeField] private Dissolve dissolveEffect;

    public void TakeDamage(float damage)
    {
        floatVariable.RuntimeValue -= damage;

        if (floatVariable.RuntimeValue <= 0) { Kill(); }
    }

    public void RestoreHealth(float restore)
    {
        floatVariable.RuntimeValue += restore;

        if (floatVariable.RuntimeValue > floatVariable.InitialValue) { floatVariable.RuntimeValue = floatVariable.InitialValue; }
    }

    public void PlayEffect()
    {
        if (dissolveEffect != null)
        {
            dissolveEffect.IsDissolving = true;
        }
    }

    public void Kill()
    {
        // TODO make this with out the hard coded Destroy call;
        PlayEffect();
        Destroy(gameObject, 4);
    }
}
