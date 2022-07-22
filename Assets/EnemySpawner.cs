using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float xBound, yBound1,yBound2,spawnRate;
    float randomX,randomY;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    public void SpawnEnemy()
    {
        randomX = Random.Range(-xBound,xBound);
        randomY = Random.Range(yBound1,yBound2);
        Vector2 randomVector = new Vector2(randomX,randomY);
        Instantiate(enemyPrefab,randomVector,transform.rotation);
    }

}
