﻿/* Gives a character access to stamina to give limitations on abilities they can use */

using UnityEngine;

public class StaminaComponent : MonoBehaviour
{
    [SerializeField] private FloatVariable stamina = null;
    [SerializeField] private float recoveryAmount = 0f; 

    private void Update()
    {
        RecoverStamina();
    }

    // Recovers lost stamina over time in seconds
    private void RecoverStamina()
    {
        if (stamina.RuntimeValue < stamina.InitialValue)
            stamina.RuntimeValue += recoveryAmount * Time.deltaTime;
    }
}
