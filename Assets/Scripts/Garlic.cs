using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garlic : Items
{
    CircleCollider2D garlicRange;
    SpriteRenderer spriteRenderer;
    [SerializeField] float gCooldown, gDamage, gArea, gDuration;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] GameObject itemimage;
    int item_Level;
    Enemy enemy;
    float cooldownSaver;
    public Garlic()
    {
        cooldown = gCooldown;
        damage = gDamage;
        area = gArea;
        duration = gDuration;
        name = "Soðan";
        description = "Etrafýndaki alana giren düþmanlara hasar verir.";
        itemImage = itemimage.GetComponent<Image>().sprite;
        itemLevel = item_Level;
    }

    void Start()
    {
        
        enemies = new List<Enemy>();
        garlicRange = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        garlicRange.isTrigger = true;
        garlicRange.radius = area;
        
        cooldownSaver = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= 1*Time.deltaTime;
        if (cooldown <= 0)
        {
            for(int i = 0; i < enemies.Count; i++)
            {

                if (((MonoBehaviour)enemies[i]) == null)
                {
                    enemies.RemoveAt(i);
                    Debug.Log("Remove etti" + enemies[i].name);
                    
                }
                else
                {
                    enemies[i].GetDamaged(damage);
                    Debug.Log("Listedeki enemy e damage attý"+ enemies[i].name);
                }
            }
            //foreach (Enemy enemy in enemies)
            //{

            //    if (enemy == null)
            //    {
            //        enemies.Remove(enemy);
            //    }
            //    else
            //    {
            //        enemy.GetDamaged(damage);
            //    }
            //}
            cooldown = cooldownSaver;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Enemy") && collision != null)
        {
            enemies.Add(collision.GetComponent<Enemy>());
            Debug.Log(collision.gameObject.name + "eklendi");
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemies.Remove(collision.GetComponent<Enemy>());
    }
    //hatayý gider
}
