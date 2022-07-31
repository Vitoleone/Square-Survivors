using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamageItem : MonoBehaviour
{
    // Start is called before the first frame update
    EquipmentItem addDamageItem;
    Player player;
    void Start()
    {
        addDamageItem = Resources.Load("AddDamageItem") as EquipmentItem;
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(addDamageItem.isLevelUp)
        {
            player.playerDamage += (player.playerDamage/10)*addDamageItem.itemLevel;
            addDamageItem.isLevelUp = false;
            Debug.Log(player.playerDamage);
        }
    }
}
