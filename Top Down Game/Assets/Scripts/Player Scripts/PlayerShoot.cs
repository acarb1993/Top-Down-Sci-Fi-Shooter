using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private WeaponContainer weaponContainer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") )
        {
            // Get the first weapon in the weapon container to shoot
            RangedWeapon weapon = weaponContainer.GetWeaponAtIndex(0);
            weapon.Shoot();
        }
    }
}
