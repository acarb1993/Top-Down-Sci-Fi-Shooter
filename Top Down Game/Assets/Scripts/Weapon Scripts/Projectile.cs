﻿/* Base class used for ammunition in the game, will despawn after a certain amount of time if it never hits a target */

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected ProjectileStats projectileStats;

    [SerializeField]
    protected GameObject impact;

    public ProjectileStats BulletStats { get { return projectileStats; } }

    protected float damage, bulletVelocity, despawnTime;

    // Name of the object, this is how the spawn will be identified in the object pooler
    protected string pName;

    protected Rigidbody2D rb;

    protected void OnEnable()
    {
        pName = projectileStats.PName;
        damage = projectileStats.Damage;
        bulletVelocity = projectileStats.BulletVelocity;
        despawnTime = projectileStats.DespawnTime;

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * bulletVelocity;

        Invoke("Despawn", despawnTime);
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy") ) {
            HealthComponent enemyHealth = collider.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(damage);
            Despawn();
        }

        GameObject particle = Instantiate(impact, transform.position, transform.rotation);
        Destroy(particle, 3);
    }

    public void SpawnProjectile(Transform spawnPoint)
    {
        ObjectPooler.Instance.GetPooledObject(projectileStats.PName, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    protected void Despawn()
    {
        // Goes back into the object pooler
        gameObject.SetActive(false);
    }
}
