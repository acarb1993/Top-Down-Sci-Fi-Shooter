using UnityEngine;

public class SupplyDrone : MonoBehaviour, IInteractable
{
    [SerializeField] private UIShop shop;

    public void OnInteract()
    {
        shop.ShowShop();
    }

    public void OnOutOfRange()
    {
        shop.HideShop();
    }

}
