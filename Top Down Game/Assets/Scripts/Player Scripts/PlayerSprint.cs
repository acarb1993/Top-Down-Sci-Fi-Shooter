﻿using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    [SerializeField] private FloatVariable stamina = null; 
    [SerializeField] private FloatVariable playerSpeed = null;
    [SerializeField] private FloatVariable sprintSpeed = null;
    [SerializeField] private FloatVariable sprintCost = null;

    // Needs to work with the Fixed Update in movement
    void FixedUpdate()
    {
        if(Input.GetButton("Run") && stamina.RuntimeValue > 0)
        {
            playerSpeed.RuntimeValue = sprintSpeed.RuntimeValue;
            stamina.RuntimeValue -= sprintCost.RuntimeValue * Time.deltaTime;
        }

        else { playerSpeed.RuntimeValue = playerSpeed.InitialValue; }
    }
}
