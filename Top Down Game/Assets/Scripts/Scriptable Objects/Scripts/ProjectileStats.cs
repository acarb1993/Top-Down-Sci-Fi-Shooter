/* Data class for any Bullet type objects */

using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Stats", menuName = "Projectiles/Projectile Stats")]
public class ProjectileStats: ScriptableObject
{
    [SerializeField]
    string pName = "";

    public string PName { get { return pName; } }

    [SerializeField]
    protected float damage, bulletVelocity, despawnTime;

    public float Damage { get { return damage; } }
    public float BulletVelocity { get { return bulletVelocity; } }
    public float DespawnTime { get { return despawnTime; } }
}
