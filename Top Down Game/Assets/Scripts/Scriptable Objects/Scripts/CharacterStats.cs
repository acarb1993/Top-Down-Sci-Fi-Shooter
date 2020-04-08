// Character attribute class, used as a base for shared attributes among all characters in game

using UnityEngine;

public abstract class CharacterStats : ScriptableObject
{
    [Header("Movement Attributes")]
    [SerializeField]
    protected float moveSpeed;

    public float MoveSpeed { get { return moveSpeed; } }

    [Header("Health Attributes")]
    [SerializeField]
    protected float startingHealth;

    public float StartingHealth { get { return startingHealth; } }
}
