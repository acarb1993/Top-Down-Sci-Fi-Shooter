using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    private Transform container;
    private Transform shopItemTemplate;
    private float offset;

    private void Awake()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("Shop Item");
        // Stays hidden until activated
        shopItemTemplate.gameObject.SetActive(false);
        offset = 10;
    }

    private void Start()
    {
        // Populate the shopping items
        for(int i = 0; i < items.Count; i++)
        {
            // Game object should have a separate "Graphics" child object
            GameObject itemObject = items[i].gameObject;
            Sprite sprite = itemObject.GetComponentInChildren<SpriteRenderer>().sprite;
            string name = itemObject.name;
            // TODO give items an actual cost
            int cost = 100;
            CreateItemButton(sprite, name, cost, i);
            
        }
    }

    // Create a new shop item to list in the UI
    private void CreateItemButton(Sprite sprite, string name, int cost, int posIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = shopItemRectTransform.rect.height - offset;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * posIndex);

        // Get all of the objects to be utilized from the template
        shopItemTransform.Find("Item Text").GetComponent<TextMeshProUGUI>().SetText(name);
        shopItemTransform.Find("Price Text").GetComponent<TextMeshProUGUI>().SetText(cost.ToString() );
        shopItemTransform.Find("Item Icon").GetComponent<Image>().sprite = sprite;
    }
}
