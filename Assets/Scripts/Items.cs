using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public float cooldown,damage,area,duration;
    public string description, name;
    public int itemLevel;
    public Sprite itemImage;
   

    private void Start()
    {
        
    }

    private void Update()
    {
    }

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
    public Items(Missle missle)
    {
        this.cooldown = missle.cooldown;
        this.description = missle.description;
        this.damage = missle.damage;
        this.area =  missle.area;
        this.duration = missle.duration;
        this.itemLevel = missle.itemLevel;
        this.name = missle.name;
        

    }
    public Items(Garlic garlic)
    {
        this.cooldown = garlic.cooldown;
        this.description = garlic.description;
        this.damage = garlic.damage;
        this.area = garlic.area;
        this.duration = garlic.duration;
        this.itemLevel = garlic.itemLevel;
        this.name = garlic.name;


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
    

}


