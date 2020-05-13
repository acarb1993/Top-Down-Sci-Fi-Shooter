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
    }

    private void SwitchWeapon(int index)
    {
        weaponContainer.GetWeaponAtIndex(index);
    }
}
