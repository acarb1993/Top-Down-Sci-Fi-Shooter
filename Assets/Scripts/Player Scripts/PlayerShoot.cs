using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // A child that is on the player
    [SerializeField] private WeaponContainer weaponContainer = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") )
        {
            weaponContainer.CurrentWeapon.Shoot();
        }

        if(Input.GetButtonDown("Reload"))
        {
            weaponContainer.CurrentWeapon.Reload();
        }

        if(Input.GetButtonDown("Weapon1") )
        {
            SwitchWeapon(0);
        }

        if (Input.GetButtonDown("Weapon2"))
        {
            SwitchWeapon(1);
        }
    }

    private void SwitchWeapon(int index)
    {
        weaponContainer.GetWeaponAtIndex(index);
    }
}
