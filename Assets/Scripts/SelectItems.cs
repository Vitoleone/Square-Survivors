using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectItems : MonoBehaviour
{
    public int numberOfColumn;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    public int ySpaceBetweenItems;
    public EquippedItems selectorItem;
    void Start()
    {
        DisplayItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayItems()
    {
        for (int i = 0; i < selectorItem.items.Count; i++)
        {
            var obj = Instantiate(selectorItem.items[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            var nameText = obj.transform.Find("ItemName");
            var descriptionText = obj.transform.Find("ItemDescription");
            var levelText = obj.transform.Find("ItemLevel");

            nameText.GetComponent<TextMeshProUGUI>().text = selectorItem.items[i].item.itemName;
            descriptionText.GetComponent<TextMeshProUGUI>().text = selectorItem.items[i].item.description;
            levelText.GetComponent<TextMeshProUGUI>().text = "Level: " + selectorItem.items[i].item.itemLevel.ToString();
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumn)), yStart + (-ySpaceBetweenItems * (i / numberOfColumn)), 0f);
    }
}
