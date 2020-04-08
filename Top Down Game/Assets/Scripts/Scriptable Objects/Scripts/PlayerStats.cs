/* Player attribute class */

using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "Player Objects/Player Stats")]
public class PlayerStats : CharacterStats
{
    [Header("Movement Attributes")]
    [SerializeField]
    private float runSpeed;

    public float RunSpeed { get { return runSpeed; } }

    [Header("Stamina Attributes")]
    [SerializeField]
    protected float startingStamina;
    [SerializeField]
    protected float staminaRecoveryRate;
    [SerializeField]
    protected float runStaminaCost;

    public float StartingStamina { get { return startingStamina; } }
    public float StaminaRecoveryRate { get { return staminaRecoveryRate; } }
    public float RunStaminaCost { get { return runStaminaCost; } }
}
