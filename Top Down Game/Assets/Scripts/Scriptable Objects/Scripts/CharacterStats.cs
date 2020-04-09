// Character attribute class, used as a base for shared attributes among all characters in game

using UnityEngine;

public abstract class CharacterStats : ScriptableObject
{
    [Header("Movement Attributes")]
    [SerializeField]
    protected float walkSpeed;

    public float WalkSpeed { get { return walkSpeed; } }

    [Header("Health Attributes")]
    [SerializeField]
    protected float startingHealth;

    public float StartingHealth { get { return startingHealth; } }
}
