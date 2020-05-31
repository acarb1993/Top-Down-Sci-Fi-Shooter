using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    [SerializeField] private FloatVariable stamina = null; 
    [SerializeField] private FloatVariable playerSpeed = null;
    [SerializeField] private FloatVariable sprintSpeed = null;
    [SerializeField] private FloatVariable sprintCost = null;

    public void Sprint()
    {
        if(stamina.RuntimeValue >= 0)
        {
            playerSpeed.RuntimeValue = sprintSpeed.RuntimeValue;
            // Reduces stamina per second
            stamina.RuntimeValue -= sprintCost.RuntimeValue * Time.deltaTime;
        }
        
        else { playerSpeed.RuntimeValue = playerSpeed.InitialValue; }
    }

    public void StopSprinting()
    {
        playerSpeed.RuntimeValue = playerSpeed.InitialValue;
    }
}
