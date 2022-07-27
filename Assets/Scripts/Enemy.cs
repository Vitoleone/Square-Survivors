using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, speed, damage;
    public GameObject exp;
    GameObject player;
    public ParticleSystem particle;
    public GameObject enemySpawnerList;
    public EquipmentItem magicMissleItem;

    private void Start()
    {
        player = GameObject.Find("Player");
        enemySpawnerList = GameObject.Find("EnemySpawner");
    }

    private void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            
        }
        
    }
    
    public void GetDamaged(float damage)
    {
        
        health -= damage;
        
        if (health <= 0)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            enemySpawnerList.GetComponent<EnemySpawner>().enemyList.Remove(gameObject);//ölen enemy enemyList den silinsin ki ona tekrar ulaþmaya çalýþmayalým
            Destroy(gameObject);

        }
    }

}


