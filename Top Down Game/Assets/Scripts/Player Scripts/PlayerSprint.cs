using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    private CharacterStatusContainer statusContainer;

    private StaminaComponent sc;
    private PlayerMovement pm;

    public float SprintSpeed { get; set; }
    public float SprintCost { get; set; }

    void Awake()
    {
        statusContainer = GetComponent<CharacterStatusContainer>();
        sc = GetComponent<StaminaComponent>();
        pm = GetComponent<PlayerMovement>();
    }

    // Needs to work with the Fixed Update in movement
    void FixedUpdate()
    {
        if(Input.GetButton("Run") && sc.CurrentStamina > 0)
        {
            pm.MoveSpeed = SprintSpeed;
            sc.ReduceStamina(SprintCost);
        }

        else { pm.MoveSpeed = pm.WalkSpeed; }
    }
}
