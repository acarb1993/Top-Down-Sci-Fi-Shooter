using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private int maxAmmo = 20;
    public int CurrentAmmo { get; private set; }

    [SerializeField]
    private float fireRate = 2, reloadSpeed = 5;
    private float timer;

    private bool reloading = false;

    private void Start()
    {
        timer = 0;

        CurrentAmmo = maxAmmo;
    }

    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }
    }

    public void Shoot()
    {
        if (timer <= 0 && CurrentAmmo > 0)
        {        
            projectile.SpawnProjectile(firePoint);

            CurrentAmmo--;

            timer = fireRate;
        }

        if (CurrentAmmo <= 0 && !reloading) {
            Debug.Log("Reloading...");
            reloading = true;
            Invoke("Reload", reloadSpeed);
        }
    }

    public void Reload()
    {
        CurrentAmmo = maxAmmo;
        reloading = false;
        Debug.Log("Reloaded");     
    }
}
