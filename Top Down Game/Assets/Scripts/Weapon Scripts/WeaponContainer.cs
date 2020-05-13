using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    private List<RangedWeapon> weapons;
    public RangedWeapon CurrentWeapon { get; private set; }

    void Start()
    {
        weapons = new List<RangedWeapon>();

        // Get each weapon in the container
        foreach (Transform child in transform)
        {
            RangedWeapon weapon = child.GetComponent<RangedWeapon>();
            weapon.gameObject.SetActive(false);
            weapons.Add(weapon);
        }

        CurrentWeapon = weapons[0];
        CurrentWeapon.gameObject.SetActive(true);
    }

    public RangedWeapon GetWeaponAtIndex(int index)
    {
        // If an invalid selection happens, just return the current weapon
        if (index < 0 || index > weapons.Count)
        {
            return CurrentWeapon;
        }

        // Disable old weapon
        CurrentWeapon.gameObject.SetActive(false);

        // Activate the new weapon and deactivate the old one
        weapons[index].gameObject.SetActive(true);

        CurrentWeapon = weapons[index];

        return weapons[index];
    }
}
