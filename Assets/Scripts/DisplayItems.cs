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
    Dictionary<ItemSlot, GameObject> itemsDisplayed = new Dictionary<ItemSlot, GameObject> ();
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
