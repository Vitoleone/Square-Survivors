using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Garlic", menuName = "ScriptableObjects/CreateGarlic")]
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

    //public Garlic()
    //{
    //    cooldown = gCooldown;
    //    damage = gDamage;
    //    area = gArea;
    //    duration = gDuration;
    //    name = "Soðan";
    //    description = "Etrafýndaki alana giren düþmanlara hasar verir.";
    //    //itemImage = itemimage.GetComponent<Image>().sprite;
    //    itemLevel = item_Level;
    //}

    

    public override void OnTriggerEnter2D(Collider2D itemCollider, Collider2D otherCollidern)
    {
        if(itemCollider!=garlicRange)
        {
            return;
        }
      
        if (otherCollidern.CompareTag("Enemy") && otherCollidern != null)
        {
            enemies.Add(otherCollidern.GetComponent<Enemy>());
            Debug.Log(otherCollidern.gameObject.name + "eklendi");
        }
        
    }
    public override void OnTriggerExit2D(Collider2D itemCollider, Collider2D otherCollider)
    {
        if (itemCollider != garlicRange)
        {
            return;
        }
        enemies.Remove(otherCollider.GetComponent<Enemy>());
    }

    public override void OnEquipped(Player player)
    {
        enemies = new List<Enemy>();
        garlicRange = player.gameObject.GetComponentInChildren<CircleCollider2D>();
        
        garlicRange.radius = area;
        cooldownSaver = cooldown;
        
    }

    public override void Update()
    {
        cooldown -= 1 * Time.deltaTime;
        if (cooldown <= 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {

                if (((MonoBehaviour)enemies[i]) == null)
                {
                    enemies.RemoveAt(i);
                    Debug.Log("Remove etti" + enemies[i].name);

                }
                else
                {
                    enemies[i].GetDamaged(damage);
                    Debug.Log("Listedeki enemy e damage attý" + enemies[i].name);
                }
            }

            cooldown = cooldownSaver;
        }
    }
    
    //hatayý gider
}
