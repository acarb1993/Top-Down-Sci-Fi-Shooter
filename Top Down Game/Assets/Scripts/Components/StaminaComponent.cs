/* Gives a character access to stamina to give limitations on abilities they can use */

using UnityEngine;

public class StaminaComponent : MonoBehaviour
{
    [SerializeField]
    public float MaxStamina { get; set; }
    public float RecoveryAmount { get; set;  }
    public float CurrentStamina { get; set; }

    void Start()
    {
        CurrentStamina = MaxStamina;
    }

    private void Update()
    {
        RecoverStamina();
    }

    // Reduces the stamina in cost per second
    public void ReduceStamina(float cost)
    {
        CurrentStamina -= cost * Time.deltaTime;
    }

    // Recovers lost stamina over time in seconds
    private void RecoverStamina()
    {
        if (CurrentStamina < MaxStamina)
            CurrentStamina += RecoveryAmount * Time.deltaTime;
    }
}
