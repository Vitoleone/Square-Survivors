using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Items : ScriptableObject
{
    public float cooldown,damage,area,duration;
    public string description, name;
    public int itemLevel;
    public Sprite itemImage;
    public abstract void OnEquipped(Player player);
    public abstract void Update();
    

   

    public Items()
    {
        this.cooldown = 0;
        this.description = "Default Description";
        this.damage = 0;
        this.area = 0;
        this.duration = 0;
        this.itemLevel = 0;
        this.name = "Default Item Name";
        this.itemImage = null;
    }
  
    
    public Items(float cooldown,float damage, float area, float duration,string name, string description, int itemLevel) 
    {
        this.cooldown = cooldown;
        this.damage = damage;
        this.area = area;
        this.duration = duration;
        this.itemLevel = itemLevel;
        this.name = name;
        this.description = description;
    }
    public abstract void OnTriggerEnter2D(Collider2D itemCollider, Collider2D otherCollider);
    public abstract void OnTriggerExit2D(Collider2D itemCollider, Collider2D otherCollider);

}


