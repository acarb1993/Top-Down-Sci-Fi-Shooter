/* Gives the player visual information of their stats such as Health and Stamina.
 * This will feed info into the UI so the player has a visual representation of their stats
 * affected in gameplay
 */

using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Image radialHealthBar, radialStaminaBar;

    [SerializeField]
    private Text ammoCounter;

    [SerializeField]
    FloatVariable playerHealth, playerStamina;

    private WeaponContainer weaponContainer;

    private void Start()
    {
        weaponContainer = transform.Find("Weapon Container").gameObject.GetComponent<WeaponContainer>(); ;
        if (weaponContainer == null) { Debug.Log("No Weapon Container found in UI"); }

        if (radialHealthBar == null) { Debug.Log("Player missing Health Bar UI"); }

        if (radialStaminaBar == null) { Debug.Log("Player missing Stamina Bar UI"); }

        if (ammoCounter == null) { Debug.Log("Player missiing Ammo Counter Text UI"); }
    }

    void Update()
    {
        radialHealthBar.fillAmount = playerHealth.RuntimeValue / 100;

        if (playerHealth.RuntimeValue <= playerHealth.InitialValue * 0.50 && playerHealth.RuntimeValue > playerHealth.InitialValue * 0.20)
            radialHealthBar.GetComponent<Image>().color = Color.yellow;

        else if (playerHealth.RuntimeValue <= playerHealth.InitialValue * 0.20)
            radialHealthBar.GetComponent<Image>().color = Color.red;

        radialStaminaBar.fillAmount = playerStamina.RuntimeValue / 100;

        ammoCounter.text = weaponContainer.GetWeaponAtIndex(0).GetComponent<RangedWeapon>().CurrentAmmo.ToString();
    }
}
