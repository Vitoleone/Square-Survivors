using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagicMissle : MonoBehaviour
{
    public GameObject bullet;
    GameObject player;
    public float fireRate;
    float damage;
    public int bulletAmount;
    public float bulletSpeed;
    EquipmentItem magicMissle;
    public EnemySpawner EnemySpawner;
    GameObject missle;
    Vector2 missleRotation;
    
    List<GameObject> enemyList;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bullet = player.GetComponent<Player>().bullet;
        EnemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        magicMissle = Resources.Load("MagicMissle") as EquipmentItem;
        fireRate = magicMissle.coolDown;
        damage = magicMissle.damage;
        bulletSpeed = magicMissle.speedBonus;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        damage *= magicMissle.damage;
        enemyList = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enemyList;
        if(enemyList.Count > 0)
        {
            missleRotation = (-transform.position + FindClosestEnemy(enemyList).transform.position).normalized;
        }
        
       
        fireRate -= Time.deltaTime;

        if(fireRate <= 0 && missleRotation != null)
        {

            FireMissle();
            fireRate = 1;
        }
        

    }
    

    public void FireMissle()
    {  
            missle = Instantiate(bullet, transform.position, Quaternion.identity);
            missle.GetComponent<Rigidbody2D>().AddRelativeForce( missleRotation* bulletSpeed, ForceMode2D.Impulse);
    }
    IEnumerator FireDelay(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
    }

    GameObject FindClosestEnemy(List<GameObject> allEnemies)
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
         

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        return closestEnemy;
    }

}
