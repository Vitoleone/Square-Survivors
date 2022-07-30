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
    private Rigidbody2D enemyRb;
    private bool isKnockBacked = false;
    

    private void Start()
    {
        player = GameObject.Find("Player");
        enemySpawnerList = GameObject.Find("EnemySpawner");
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
        
        
    }

    

    private void Update()
    {
        if(player != null)
        
        {
             //enemyRb.velocity = (player.transform.position - transform.position) * speed*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            
        }
        
    }
    
    public void GetDamaged(float damage, float knockBackPower, float knockBackDelay)
    {
        
        health -= damage;
        
        if (health <= 0)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            enemySpawnerList.GetComponent<EnemySpawner>().enemyList.Remove(gameObject);//ölen enemy enemyList den silinsin ki ona tekrar ulaþmaya çalýþmayalým
            Destroy(gameObject);

        }
        if(knockBackPower > 0 && knockBackDelay > 0)
        {
            StartCoroutine(EnemyKnockBack(knockBackPower,knockBackDelay));
        }
        if(isKnockBacked == true)
        {
            StopCoroutine(EnemyKnockBack(knockBackPower,knockBackDelay));
            isKnockBacked = false;
        }
    }

    IEnumerator EnemyKnockBack(float knockbackPower,float knockbackDelay)
    {
        enemyRb.AddForce((transform.position - player.transform.position) * knockbackPower,ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockbackDelay);
        enemyRb.velocity = Vector2.zero;
        isKnockBacked = true;
    }

}


