using UnityEngine;

public class Biomass : MonoBehaviour, IPickupable
{
    [SerializeField] private string pName = "";

    void onEnable() {}

    public void Spawn(Transform spawnPoint)
    {
        ObjectPooler.Instance.GetPooledObject(pName, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void onPickup()
    {
        gameObject.SetActive(false);
    }
}
