using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    EquipmentItem magicMissleItem;
    ParticleSystem magicMissleParticle;
    public ParticleSystem bulletParticle;
    public int enemyCount = 1;
    void Start()
    { 
        magicMissleItem = Resources.Load("MagicMissle") as EquipmentItem;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("uglum");
            collision.gameObject.GetComponent<Enemy>().GetDamaged(magicMissleItem.damage);
            enemyCount++;
            if(enemyCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
