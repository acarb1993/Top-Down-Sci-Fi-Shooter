using System.Collections;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField] private Projectile projectile = null;
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private int maxAmmo = 20;
    [SerializeField] private float fireRate = 2, reloadSpeed = 5;

    private AudioSource audioSource;
    public int CurrentAmmo { get; private set; }

    private float timer;

    private bool reloading = false;

    private float volume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = 0;
        CurrentAmmo = maxAmmo;
        volume = 0.5f;
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
            audioSource.PlayOneShot(audioSource.clip, volume);

            CurrentAmmo--;

            timer = fireRate;
        }
    }

    public void Reload()
    {
        if(!reloading && CurrentAmmo != maxAmmo) { StartCoroutine(ReloadCommence()); }
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
