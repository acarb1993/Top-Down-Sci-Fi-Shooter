using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
   public RangedWeapon GetWeaponAtIndex(int index)
    {
        Transform child = transform.GetChild(index);

        return child.GetComponent<RangedWeapon>();
    }
}
