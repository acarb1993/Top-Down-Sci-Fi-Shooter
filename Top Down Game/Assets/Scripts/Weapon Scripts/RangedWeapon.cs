using System.Collections;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField] private Projectile projectile;

    [SerializeField] private Transform firePoint;

    [SerializeField] private int maxAmmo = 20;
    public int CurrentAmmo { get; private set; }

    [SerializeField] private float fireRate = 2, reloadSpeed = 5;

    private float timer;

    private bool reloading = false;

    private void Start()
    {
        timer = 0;
        CurrentAmmo = maxAmmo;
    }

    private void Update()
    {
        if(timer > 0) { timer -= Time.deltaTime; }
    }

    public void Shoot()
    {
        // Checks if the player can fire and if the weapon has ammo
        if (timer <= 0 && CurrentAmmo > 0 && !reloading)
        {        
            projectile.SpawnProjectile(firePoint);

            CurrentAmmo--;

            timer = fireRate;
        }
    }

    public void Reload()
    {
        StartCoroutine(ReloadCommence() );
    }

    // Reloads this weapon
    public IEnumerator ReloadCommence()
    {
        Debug.Log("Reloading");
        reloading = true;

        yield return new WaitForSeconds(reloadSpeed);
        CurrentAmmo = maxAmmo;
        reloading = false;
        Debug.Log("Reloaded");     
    }
}
