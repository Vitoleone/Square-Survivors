using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Items Slot", menuName ="Inventory System/Items Slot")]
public class EquippedItems : ScriptableObject
{
    public List<ItemSlot> items = new List<ItemSlot>();
    public void AddItem(Item _item, int _amount)
    {
        bool hasItem = false;
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].item == _item)
            {
                items[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if(!hasItem)
        {
            items.Add(new ItemSlot(_item, _amount));
        }
    }
}



[System.Serializable]
public class ItemSlot//Itemlar buraya ekleniyor
{
    public Item item;
    public int amount = 1;
    public ItemSlot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int amount)
    {
        this.amount += amount;
    }
}
