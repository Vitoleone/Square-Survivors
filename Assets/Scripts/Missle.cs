using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Missle", menuName = "ScriptableObjects/CreateMissle")]
public class Missle : Items
{
   
    
        [SerializeField] Camera mainCamera;
        [SerializeField] float bulletSpeed;
    private Player player;
    [SerializeField] float bulletDamage;
        [SerializeField] GameObject bullet;
        float randomX, randomY, shootTimer;
        [SerializeField] GameObject itemimage;
        int item_Level;
      
   
        //public Missle()
        //{
        //    cooldown = 1;
        //    damage = 10;
        //    area = 10;
        //    duration = 1;
        //    name = "Büyülü Mermi";
        //    description = "En yakýnýndaki düþmana belirli aralýklarla büyülü mermi yollar.";
        //    itemImage = itemimage.GetComponent<Image>().sprite;
        //    itemLevel = item_Level;
        //}

      
        IEnumerator FireCoroutine()
        {
            Vector3 bulletDirection = new Vector3(randomX, randomY, 0);
            bulletDirection.Normalize();
            GameObject shootingBullet = Instantiate(bullet, player.transform.position, Quaternion.identity);
            shootingBullet.transform.position.Normalize();
            shootingBullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            yield return new WaitForSeconds(shootTimer);
        }

    public override void OnEquipped(Player player)
    {
        bullet = GameObject.Find("Bullet");
        shootTimer = cooldown;
        bulletDamage = damage;
        mainCamera = Camera.main;
        bulletSpeed = 10;
        this.player = player;
    }

    public override void Update()
    {
        shootTimer -= 1 * Time.deltaTime;
        if (shootTimer <= 0)
        {
            randomX = Random.Range(-1f, 1f);
            randomY = Random.Range(-1f, 1f);
            player.StartCoroutine(FireCoroutine());
            shootTimer = 1;
        }
    }

    public override void OnTriggerEnter2D(Collider2D itemCollider, Collider2D otherCollider)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit2D(Collider2D itemCollider, Collider2D otherCollider)
    {
        throw new System.NotImplementedException();
    }
}

