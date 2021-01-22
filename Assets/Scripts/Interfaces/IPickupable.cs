using UnityEngine;

public interface IPickupable
{
    public void Spawn(Transform spawnPoint);
    public void OnPickup(Inventory inv);

    public void PlaySound();
}
