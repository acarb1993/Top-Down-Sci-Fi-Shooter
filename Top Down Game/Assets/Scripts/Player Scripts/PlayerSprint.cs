using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    [SerializeField] private FloatVariable stamina, playerSpeed, sprintSpeed, sprintCost;

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
