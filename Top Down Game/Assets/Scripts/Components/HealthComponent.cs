/* Gives any character in the game Health, allows the character to take damage and be
 * hit by attacks and abilities.
 */
using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] private FloatVariable floatVariable = null;
    // Need to change later so not every object just dissolves
    [SerializeField] private Dissolve dissolveEffect = null;

    public void TakeDamage(float damage)
    {
        floatVariable.RuntimeValue -= damage;

        if (floatVariable.RuntimeValue <= 0) { StartCoroutine(Kill() ); }
    }

    public void RestoreHealth(float restore)
    {
        floatVariable.RuntimeValue += restore;

        if (floatVariable.RuntimeValue > floatVariable.InitialValue) { floatVariable.RuntimeValue = floatVariable.InitialValue; }
    }

    // Plays a cool on death kill effect
    public IEnumerator PlayEffect()
    {
        if (dissolveEffect != null)
        {
            dissolveEffect.IsDissolving = true;
            while(dissolveEffect.IsDissolving)
            {
                yield return null;
            }
        }
    }

    // Destroys object when the kill effect is done
    public IEnumerator Kill()
    {
        yield return StartCoroutine(PlayEffect());
        Destroy(gameObject);
    }
}
