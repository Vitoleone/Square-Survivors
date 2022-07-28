using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRangeItem : MonoBehaviour
{
    EquipmentItem addRangeItem;
    Player player;

    private void Start()
    {
        addRangeItem = Resources.Load("AddRangeItem") as EquipmentItem;
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    void Update()
    {
        
        if (addRangeItem.isLevelUp == true)
        {
            player.playerRange += addRangeItem.areaBonus;
            addRangeItem.isLevelUp = false;
        }
    }
}
