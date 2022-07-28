using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health,
    Equipment,
    Default
}
public abstract class Item : ScriptableObject //Item dan nesne olu�turmak istedi�imiz i�in abstract yapt�k
{
    public GameObject prefab;
    public GameObject itemFeature;
    public EquipmentItem EquipmentItemAttributes;
    public ItemType type;

    [TextArea(15,20)]
    public string description;//E�ya a��klamas�
    public string itemName;
    public int itemLevel = 1;
    public bool isNew = true;
    public bool isLevelUp = false;

}
