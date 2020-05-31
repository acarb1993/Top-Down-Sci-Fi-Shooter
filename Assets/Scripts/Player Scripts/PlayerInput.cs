using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] WeaponContainer weaponContainer = null;

    private PlayerMovement playerMovement;
    private PlayerSprint playerSprint;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSprint = GetComponent<PlayerSprint>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1")) { weaponContainer.CurrentWeapon.Shoot(); }

        if (Input.GetButtonDown("Reload")) { weaponContainer.CurrentWeapon.Reload(); }

        if (Input.GetButtonDown("Weapon1")) { weaponContainer.GetWeaponAtIndex(0); }

        if (Input.GetButtonDown("Weapon2")) { weaponContainer.GetWeaponAtIndex(1); }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Run")) { playerSprint.Sprint(); }

        else { playerMovement.Walk(); }
    }
}
