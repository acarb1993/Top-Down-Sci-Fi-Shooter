using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    public List<RangedWeapon> Weapons { get; private set; }
    public RangedWeapon CurrentWeapon { get; private set; }

    void Start()
    {
        Weapons = new List<RangedWeapon>();

        // Get each weapon in the container
        foreach (Transform child in transform)
        {
            RangedWeapon weapon = child.GetComponent<RangedWeapon>();
            weapon.gameObject.SetActive(false);
            Weapons.Add(weapon);
        }

        CurrentWeapon = Weapons[0];
        CurrentWeapon.gameObject.SetActive(true);
    }

    public RangedWeapon GetWeaponAtIndex(int index)
    {
        // If an invalid selection happens, just return the current weapon
        if (index < 0 || index > Weapons.Count)
        {
            return CurrentWeapon;
        }

        // Disable old weapon
        CurrentWeapon.gameObject.SetActive(false);

        // Activate the new weapon and deactivate the old one
        Weapons[index].gameObject.SetActive(true);

        CurrentWeapon = Weapons[index];

        return Weapons[index];
    }
}
