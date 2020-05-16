using UnityEngine;

public class PlayerWeaponSwitch : MonoBehaviour
{
    [SerializeField] private WeaponContainer weaponContainer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            weaponContainer.GetWeaponAtIndex(0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponContainer.GetWeaponAtIndex(1);
        }
    }
}
