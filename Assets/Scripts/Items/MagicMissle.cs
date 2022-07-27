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
    GameObject magicMissleParticle;
    GameObject missle,missleParticleInstantiate;
    Vector2 missleDirection;
    float missleRotation;
    
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
        magicMissleParticle = Resources.Load("MagicMissleParticle") as GameObject;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        damage *= magicMissle.damage;
        enemyList = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enemyList;
        if(enemyList.Count > 0)
        {
            missleDirection = (-transform.position + FindClosestEnemy(enemyList).transform.position).normalized;
        }
        
       
        fireRate -= Time.deltaTime;

        if(fireRate <= 0 && missleDirection != null)
        {

            FireMissle();
            fireRate = 1;
        }
        

    }
    

    public void FireMissle()
    {
        missle = Instantiate(bullet, transform.position, Quaternion.identity);
        missle.transform.eulerAngles = new Vector3(-GetAngleFromVectorFloat(-missleDirection), 0, 0);
        missleParticleInstantiate = Instantiate(magicMissleParticle,transform.position,Quaternion.identity);
        missleParticleInstantiate.transform.eulerAngles = new Vector3(-GetAngleFromVectorFloat(-missleDirection), 90, 90);
        missleParticleInstantiate.transform.parent = missle.transform;

        missle.GetComponent<Rigidbody2D>().AddRelativeForce(missleDirection * bulletSpeed, ForceMode2D.Impulse);
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
    public float GetAngleFromVectorFloat(Vector2 direction)//merminin fýrlatýldýðý açýyý alýrýz
    {
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(angle < 0)
        {
            angle += 360;
        }
        return angle;
    }
  

}
