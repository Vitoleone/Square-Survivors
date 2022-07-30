using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    EquipmentItem magicMissleItem;
    ParticleSystem magicMissleParticle;
    public ParticleSystem bulletParticle;
    public int enemyCount = 1;//magic item �n i�erisinden ge�ebilece�i enemy say�s�(bunu daha sonra items class�na �zellik olarak ekleyip level atlad�k�a art�racaz)
    void Start()
    { 
        magicMissleItem = Resources.Load("MagicMissle") as EquipmentItem;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<Enemy>().GetDamaged(magicMissleItem.damage,magicMissleItem.knockBackPower,magicMissleItem.knockBackDelay);
            enemyCount--;
            if(enemyCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
