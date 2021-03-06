﻿ using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] WeaponContainer weaponContainer = null;

    private PlayerMovement playerMovement;
    private PlayerSprint playerSprint;
    private Vector2 moveAxis;
    private Interact interact;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSprint = GetComponent<PlayerSprint>();
        interact = GetComponent<Interact>();
    }

    // Use update for key inputs
    private void Update()
    {
        // Reads the input of the direction the player is going
        moveAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButton("Fire1") && weaponContainer.CurrentWeapon != null) { weaponContainer.CurrentWeapon.Shoot(); }

        if (Input.GetButtonDown("Reload")) { weaponContainer.CurrentWeapon.Reload(); }

        if (Input.GetButtonDown("Weapon1")) { weaponContainer.GetWeaponAtIndex(0); }

        if (Input.GetButtonDown("Weapon2")) { weaponContainer.GetWeaponAtIndex(1); }

        if (Input.GetButton("Run")) { playerSprint.Sprint(); }

        if(Input.GetButtonDown("Interact") && interact.Interactable != null) { interact.InteractWithTarget(); }

        else if (Input.GetButtonUp("Run")) { playerSprint.StopSprinting(); }
    }

    // Use FixedUpdate for physics movement
    private void FixedUpdate()
    {
        playerMovement.Move(moveAxis);
    }
}
