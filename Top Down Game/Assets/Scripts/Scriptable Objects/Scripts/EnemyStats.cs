/* Enemy attribute class, will house the data for Enemies in the game */

using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Enemy Objects/Enemy Stats")]
public class EnemyStats : CharacterStats
{
    [Header("Attack Attributes")]
    [SerializeField]
    protected float attackSpeed;
    [SerializeField]
    protected float attackDamage;
 
    public float AttackSpeed { get { return attackSpeed; } }
    public float AttackDamage { get { return attackDamage; } }
}
