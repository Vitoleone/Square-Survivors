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
        
        magicMissleParticle = Instantiate(bulletParticle,transform.position,transform.rotation);
        magicMissleItem = Resources.Load("MagicMissle") as EquipmentItem;
    }
    private void Update()
    {
        magicMissleParticle.transform.position = transform.position;
        magicMissleParticle.transform.Rotate(new Vector3(90, 90, 90));
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().GetDamaged(magicMissleItem.damage);
            enemyCount++;
            if(enemyCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
