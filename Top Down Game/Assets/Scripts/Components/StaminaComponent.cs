/* Gives a character access to stamina to give limitations on abilities they can use */

using UnityEngine;

public class StaminaComponent : MonoBehaviour
{
    [SerializeField]
    private float maxStamina = 100, recoveryAmount = 2;
    public float MaxStamina { get { return maxStamina; } }
    public float CurrentStamina { get; set; }

    // Have Awake() run so the stamina is always initialized for UI elements
    void Awake()
    {
        CurrentStamina = maxStamina;
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
        if (CurrentStamina < maxStamina)
            CurrentStamina += recoveryAmount * Time.deltaTime;
    }
}
