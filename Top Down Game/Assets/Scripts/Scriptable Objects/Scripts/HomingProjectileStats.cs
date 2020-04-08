/* Attribute class for Homing Skills these will find the closest target and damage it on impact*/

using UnityEngine;

[CreateAssetMenu(fileName = "Homing Projectile Stats", menuName = "Projectiles/Homing Projectile Stats")]
public class HomingProjectileStats : ProjectileStats
{
    // Rotate speed works better at higher numbers
    [Header("Homing Projectile Attribute")]
    [SerializeField]
    private float speed, rotateSpeed, range;

    public float Speed { get { return speed; } }
    public float RotateSpeed { get { return rotateSpeed; } }
    public float Range { get { return range; } }
}