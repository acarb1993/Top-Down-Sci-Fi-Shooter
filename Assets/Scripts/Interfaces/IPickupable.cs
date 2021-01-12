using UnityEngine;

public interface IPickupable
{
    public void Spawn(Transform spawnPoint);
    public void onPickup(); 
}
