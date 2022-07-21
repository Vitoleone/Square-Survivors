using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory System/Items/Equipment"),]
public class EquipmentItem : Item
{
    public float damageBonus;
    public float defenceBonus;
    public float maxHealthBonus;
    public float expGainBonus;
    public float cooldownBonus;
    public float speedBonus;
    public float areaBonus;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
