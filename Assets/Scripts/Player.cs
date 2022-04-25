using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Walking values
    [SerializeField] float playerSpeed;
    [SerializeField] float playerMaxHealth;
    [SerializeField] float playerHealth;
    Vector3 playerPosition;
    Vector2 playerMoveInput;
    public HealthBar healthBar;
    //----------------------------

    //Shoot Values
    [SerializeField] Camera mainCamera;
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bullet;
    float randomX, randomY, shootTimer;
    //DeadParticle
    public ParticleSystem deadParticle;


    void Start()
    {

        //movement
        playerPosition = transform.position;
        playerMoveInput.Normalize();
        //HealthBar
        playerHealth = playerMaxHealth;
        healthBar.SetHealth(playerHealth, playerMaxHealth);
        //shoot   
        shootTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        //Walking Starts
        playerMoveInput.x = Input.GetAxis("Horizontal");
        playerMoveInput.y = Input.GetAxis("Vertical");

        PlayerWalk(playerMoveInput.x, playerMoveInput.y);
        //Walking Ends

        void PlayerWalk(float directionX, float directionY)
        {
            transform.position += new Vector3((playerPosition.x + playerSpeed) * directionX * Time.deltaTime, (playerPosition.y + playerSpeed) * directionY * Time.deltaTime, 0);

        }


    
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= collision.gameObject.GetComponent<Enemy>().damage;
            healthBar.SetHealth(playerHealth, playerMaxHealth);
            if (playerHealth <= 0)
            {
                Instantiate(deadParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
            }

        }
    }
    //missle silahýný ekleme
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Item")) 
        {
            
            gameObject.AddComponent<Missle>();
        }
    }
}