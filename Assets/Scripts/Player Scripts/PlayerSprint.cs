using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    [SerializeField] private FloatVariable stamina = null; 
    [SerializeField] private FloatVariable playerSpeed = null;
    [SerializeField] private FloatVariable sprintSpeed = null;
    [SerializeField] private FloatVariable sprintCost = null;

    public void Sprint()
    {
        playerSpeed.RuntimeValue = sprintSpeed.RuntimeValue;
        // Reduces stamin per second
        stamina.RuntimeValue -= sprintCost.RuntimeValue * Time.deltaTime;
    }
}
