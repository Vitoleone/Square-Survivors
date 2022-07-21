using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Item", menuName = "Inventory System/Items/Health"),]
public class HealthItem : Item
{
    public int restoreHealthValue;
    public void Awake()
    {
        type = ItemType.Health;   
    }
}
