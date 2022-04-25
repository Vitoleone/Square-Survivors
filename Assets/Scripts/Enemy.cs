using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, speed, damage;
    public GameObject exp;
    GameObject player;
    public ParticleSystem particle;

    private void Start()
    {
        player = GameObject.Find("Player");
        
    }

    private void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            float damage = collision.gameObject.GetComponent<Bullet>().bulletDamage;
            GetDamaged(damage);
        }
    }
    public void GetDamaged(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

}


