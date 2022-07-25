using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayItems : MonoBehaviour
{
    // Start is called before the first frame update
    public EquippedItems equippedItems;
    public int numberOfColumn;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    public int ySpaceBetweenItems;
    public Dictionary<ItemSlot, GameObject> itemsDisplayed = new Dictionary<ItemSlot, GameObject> ();
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        UpdateDisplay();
    }
    public void CreateDisplay()
    {
        for (int i = 0; i < equippedItems.items.Count; i++)
        {
            var obj = Instantiate(equippedItems.items[i].item.prefab, Vector3.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = equippedItems.items[i].amount.ToString("n0");
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems *(i%numberOfColumn)), yStart + (-ySpaceBetweenItems *(i/numberOfColumn)),0f);
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < equippedItems.items.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(equippedItems.items[i]))
            {
                
                itemsDisplayed[equippedItems.items[i]].GetComponentInChildren<TextMeshProUGUI>().text = equippedItems.items[i].item.itemLevel.ToString();
            }
            else
            {
               
                var obj = Instantiate(equippedItems.items[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = equippedItems.items[i].item.itemLevel.ToString();
                itemsDisplayed.Add(equippedItems.items[i], obj);
                if (!player.transform.FindChild(equippedItems.items[i].item.itemFeature.name + "(Clone)"))//Item player üzerine eklenir
                {
                    Equipitem(equippedItems.items[i].item.itemFeature);
                }
               
            }
        }
    }
    public void Equipitem(GameObject item)
    {
        var garlicItem = Instantiate(item, player.transform.position, Quaternion.identity);
        garlicItem.transform.parent = player.transform;
    }

}
