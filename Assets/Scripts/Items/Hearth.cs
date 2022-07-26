using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hearth : MonoBehaviour//Bitmedi
{
    // Start is called before the first frame update
    GameObject player;
    GameObject itemSelected;
    Player Player;
    int healthItemIndex = 0;
    
   
    private void Start()
    {
        itemSelected = GameObject.Find("ItemSelected");
        player = GameObject.Find("Player");
        Player = player.GetComponent<Player>();
       
        
    }
    private void Update()
    {
        for (int i = 0; i < Player.equippedItems.items.Count; i++)
        {
            if(Player.equippedItems.items[i] != null && Player.equippedItems.items[i].item.itemName == "Health")
            {
                healthItemIndex = i;
            }
        }
       
        if(Player.equippedItems.items[healthItemIndex].item.isLevelUp)
        {
            IncreaseMaxHealth(20);
        }
    }
    public void IncreaseMaxHealth(float value)
    {
       
        player.GetComponent<Player>().playerMaxHealth += value;
        if(Player.playerHealth+value >= Player.playerMaxHealth)
        {
            Player.playerHealth = Player.playerMaxHealth;
        }
        else
        {
            Player.playerHealth += value;
        }
        
        Player.equippedItems.items[healthItemIndex].item.isLevelUp = false;


    }
    
}
