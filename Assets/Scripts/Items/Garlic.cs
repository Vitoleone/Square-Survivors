using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garlic : MonoBehaviour
{
    // Start is called before the first frame update
    public float garlicRange = 1;
    private float playerRange;
    EquipmentItem garlic;
    List<Collider2D> colliders;
    GameObject player;
    bool isOk = false;
    void Start()
    {
        player = GameObject.Find("Player");
        playerRange = player.GetComponent<Player>().playerRange;
        colliders = new List<Collider2D>();
        garlic = Resources.Load("Garlic") as EquipmentItem;
        
        StartCoroutine(GarlicCooldown(garlic.coolDown));


    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerRange != player.GetComponent<Player>().playerRange)//Player range i deðiþirse yenisine eþitle.
        {
            UpdatePlayerRange();
        }
        //alan içerisine giren düþmanlarýn colliderini listeye ekler
        if(Physics2D.OverlapCircle(transform.position, garlic.range + playerRange).CompareTag("Enemy"))
        {
            colliders.Add(Physics2D.OverlapCircle(transform.position, garlic.range + playerRange));
        }
        
        if (isOk)
        {

            
            isOk = false;
            GarlicDamage(colliders);
            StartCoroutine(GarlicCooldown(garlic.coolDown));
        }
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, garlic.range + playerRange);
    }
    void UpdatePlayerRange()
    {
        playerRange = player.GetComponent<Player>().playerRange;
    }
    public void LevelUp()
    {
        garlic.itemLevel++;
        if(garlic.itemLevel % 2 == 0)
        {
            garlic.range += 0.5f;
        }
        else
        {
            garlic.damage += 10;
        }
    }
    void GarlicDamage(List<Collider2D> colliders)
    {
        List<Collider2D> attacked = new List<Collider2D>();
        foreach (Collider2D collider in colliders.ToArray())
        {
            if(!collider.GetComponent<BoxCollider2D>().enabled)
            {
                colliders.Remove(collider);
            }
            if (collider.CompareTag("Enemy") && collider != null && !attacked.Contains(collider))
            {
                collider.GetComponent<Enemy>().GetDamaged(garlic.damage);
                attacked.Add(collider);
                
                
            }
            
        }
        attacked.Clear();
        colliders.Clear();
        
        

    }
    IEnumerator GarlicCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        isOk = true;
    }
    
   
}
