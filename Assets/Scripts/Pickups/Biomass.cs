using UnityEngine;

public class Biomass : MonoBehaviour, IPickupable
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void onPickup()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
    }
}
