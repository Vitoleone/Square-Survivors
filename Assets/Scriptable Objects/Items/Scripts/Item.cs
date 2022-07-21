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
    public ItemType type;

    [TextArea(15,20)]
    public string description;//Eþya açýklamasý

}
