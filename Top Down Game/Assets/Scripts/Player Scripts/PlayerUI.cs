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

    private HealthComponent hc;
    private StaminaComponent sc;
    private WeaponContainer wc;

    private void Start()
    {
        // Root is the player gameobject, separate child object is used for UI
        hc = GetComponent<HealthComponent>();
        if (hc == null) { Debug.Log("No HealthComponent found in UI"); }

        sc = GetComponent<StaminaComponent>();
        if (sc == null) { Debug.Log("No StaminaComponent found in UI"); }

        wc = transform.Find("Weapon Container").gameObject.GetComponent<WeaponContainer>(); ;
        if (wc == null) { Debug.Log("No Weapon Container found in UI"); }

        if (radialHealthBar == null) { Debug.Log("Player missing Health Bar UI"); }

        if (radialStaminaBar == null) { Debug.Log("Player missing Stamina Bar UI"); }

        if (ammoCounter == null) { Debug.Log("Player missiing Ammo Counter Text UI"); }
    }

    void Update()
    {
        radialHealthBar.fillAmount = hc.CurrentHealth / 100;

        if (hc.CurrentHealth <= hc.MaxHealth * 0.50 && hc.CurrentHealth > hc.MaxHealth * 0.20)
            radialHealthBar.GetComponent<Image>().color = Color.yellow;

        else if (hc.CurrentHealth <= hc.MaxHealth * 0.20)
            radialHealthBar.GetComponent<Image>().color = Color.red;

        radialStaminaBar.fillAmount = sc.CurrentStamina / 100;

        ammoCounter.text = wc.GetWeaponAtIndex(0).GetComponent<RangedWeapon>().CurrentAmmo.ToString();
    }
}
