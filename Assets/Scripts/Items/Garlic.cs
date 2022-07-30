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
    GameObject GarlicParticle,GarlicParticleInstantiate;
    Player player;
    bool isOk = false;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        
        colliders = new List<Collider2D>();
        garlic = Resources.Load("Garlic") as EquipmentItem;
        GarlicParticle = Resources.Load("GarlicParticle") as GameObject;
        GarlicParticleInstantiate = Instantiate(GarlicParticle,transform.position,Quaternion.identity);
        StartCoroutine(GarlicCooldown(garlic.coolDown));


    }

    // Update is called once per frame
    void Update()
    {
        
        playerRange = player.playerRange;
        GarlicParticleInstantiate.transform.position = transform.position;
        GarlicParticleInstantiate.transform.localScale = new Vector3(playerRange + garlicRange, playerRange + garlicRange);
        if (playerRange != player.GetComponent<Player>().playerRange)//Player range i deðiþirse yenisine eþitle.
        {
            UpdatePlayerRange();
        }
        //alan içerisine giren düþmanlarýn colliderini listeye ekler
        if(Physics2D.OverlapCircle(transform.position, garlic.range + playerRange) != null)
        {
            if (Physics2D.OverlapCircle(transform.position, garlic.range + playerRange).CompareTag("Enemy"))
            {
                colliders.Add(Physics2D.OverlapCircle(transform.position, garlic.range + playerRange));
            }
        }
        
        
        if (isOk)
        {
            foreach (Collider2D collider in colliders)
            {
                if(collider == null)
                {
                    colliders.Remove(collider);
                }
            }
            
            isOk = false;
            GarlicDamage(colliders);
            Debug.Log("Hasar Vurdu");
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
    public void LevelUp()//Henüz tamamlanmadý
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
            if(collider == null)
            {
                colliders.Remove(collider);
            }
            if (collider.CompareTag("Enemy") && collider != null && !attacked.Contains(collider))
            {
                collider.GetComponent<Enemy>().GetDamaged(garlic.damage,garlic.knockBackPower,garlic.knockBackDelay);
                collider.GetComponent<Rigidbody2D>().AddRelativeForce((collider.transform.position - transform.position) * 2f, ForceMode2D.Impulse);
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
