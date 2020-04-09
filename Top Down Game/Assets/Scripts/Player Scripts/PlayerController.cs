/* Houses access of the player data for a scriptable object to initalize values */

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;

    private HealthComponent healthComponent;
    private StaminaComponent staminaComponent;
    private PlayerMovement playerMovement;
    private PlayerSprint playerSprint;

    void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        staminaComponent = GetComponent<StaminaComponent>();
        playerMovement = GetComponent<PlayerMovement>();
        playerSprint = GetComponent<PlayerSprint>();

        healthComponent.MaxHealth = playerStats.StartingHealth;
        staminaComponent.MaxStamina = playerStats.StartingStamina;
        staminaComponent.RecoveryAmount = playerStats.StaminaRecoveryRate;
        playerMovement.WalkSpeed = playerStats.WalkSpeed;
        playerSprint.SprintSpeed = playerStats.SprintSpeed;
        playerSprint.SprintCost = playerStats.SprintStaminaCost;
    }
}
