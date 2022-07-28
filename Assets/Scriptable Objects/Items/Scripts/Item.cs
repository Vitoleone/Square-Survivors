using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health,
    Equipment,
    Default
}
public abstract class Item : ScriptableObject //Item dan nesne oluþturmak istediðimiz için abstract yaptýk
{
    public GameObject prefab;
    public GameObject itemFeature;
    public EquipmentItem EquipmentItemAttributes;
    public ItemType type;

    [TextArea(15,20)]
    public string description;//Eþya açýklamasý
    public string itemName;
    public int itemLevel = 1;
    public bool isNew = true;
    public bool isLevelUp = false;

}
