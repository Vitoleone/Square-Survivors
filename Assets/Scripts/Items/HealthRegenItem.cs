using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegenItem : MonoBehaviour
{
    Player player;
    EquipmentItem healthRegenItem;
    float healthRegenAmount = 0.3f;

    private void Start()
    {
        player = GetComponent<Player>();
        healthRegenItem = Resources.Load("HealthRegenItem") as EquipmentItem;
    }

    private void Update()
    {
        RegenerateHealth();
    }

    public void RegenerateHealth()
    {
        if(healthRegenItem.isLevelUp)
        {
            player.playerHealthRegen += healthRegenAmount;
            healthRegenItem.isLevelUp = false;
        }
        
    }
}
