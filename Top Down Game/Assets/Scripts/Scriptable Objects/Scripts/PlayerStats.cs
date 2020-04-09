/* Player attribute class */

using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Player Objects/Player Stats")]
public class PlayerStats : CharacterStats
{
    [Header("Movement Attributes")]
    [SerializeField]
    private float sprintSpeed;

    public float SprintSpeed { get { return sprintSpeed; } }

    [Header("Stamina Attributes")]
    [SerializeField]
    protected float startingStamina;
    [SerializeField]
    protected float staminaRecoveryRate;
    [SerializeField]
    protected float sprintStaminaCost;

    public float StartingStamina { get { return startingStamina; } }
    public float StaminaRecoveryRate { get { return staminaRecoveryRate; } }
    public float SprintStaminaCost { get { return sprintStaminaCost; } }
}
