using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Inventory inv;

    void Start()
    {
        inv = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickupable pickup = collision.GetComponent<IPickupable>();
        if (pickup != null)
        {
            pickup.onPickup(inv);
        }
    }
}
