using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missle : Items
{
   
    
        [SerializeField] Camera mainCamera;
        [SerializeField] float bulletSpeed;
        [SerializeField] float bulletDamage;
        [SerializeField] GameObject bullet;
        float randomX, randomY, shootTimer;
        [SerializeField] GameObject itemimage;
        int item_Level;
        private void Start()
        {
        bullet = GameObject.Find("Bullet");    
        shootTimer = cooldown;
        bulletDamage = damage;
        mainCamera = Camera.main;
        bulletSpeed = 10;
        }
   
        public Missle()
        {
            cooldown = 1;
            damage = 10;
            area = 10;
            duration = 1;
            name = "Büyülü Mermi";
            description = "En yakýnýndaki düþmana belirli aralýklarla büyülü mermi yollar.";
            itemImage = itemimage.GetComponent<Image>().sprite;
            itemLevel = item_Level;
        }

        private void Update()
        {
            shootTimer -= 1*Time.deltaTime;
            if (shootTimer <= 0)
            {
                randomX = Random.Range(-1f, 1f);
                randomY = Random.Range(-1f, 1f);
                StartCoroutine(FireCoroutine());
                shootTimer = 1;
            }
        }
        IEnumerator FireCoroutine()
        {
            Vector3 bulletDirection = new Vector3(randomX, randomY, 0);
            bulletDirection.Normalize();
            GameObject shootingBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            shootingBullet.transform.position.Normalize();
            shootingBullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            yield return new WaitForSeconds(shootTimer);
        }

}

