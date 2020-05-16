using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // A child that is on the player
    [SerializeField] private WeaponContainer weaponContainer;

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

        if(Input.GetKeyDown(KeyCode.Alpha1) )
        {
            SwitchWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
    }

    private void SwitchWeapon(int index)
    {
        weaponContainer.GetWeaponAtIndex(index);
    }
}
