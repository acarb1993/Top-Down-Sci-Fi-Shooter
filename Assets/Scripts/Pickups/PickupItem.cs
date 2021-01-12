using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        inv = GetComponent<Inventory>();
    }

    // Automatically get pickups when dropped by enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickupable pickup = collision.GetComponent<IPickupable>();
        if (pickup != null)
        {
            pickup.onPickup(inv);
        }
    }
}
