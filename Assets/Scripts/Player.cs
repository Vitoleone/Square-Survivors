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
    float randomX, randomY;
    //DeadParticle
    public ParticleSystem deadParticle;
    public List<Items> items;


    void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].OnEquipped(this);
        }
        //movement
        playerPosition = transform.position;
        playerMoveInput.Normalize();
        //HealthBar
        playerHealth = playerMaxHealth;
        healthBar.SetHealth(playerHealth, playerMaxHealth);
        //shoot   
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //Walking Starts
        playerMoveInput.x = Input.GetAxis("Horizontal");
        playerMoveInput.y = Input.GetAxis("Vertical");
        for(int i = 0; i < items.Count; i++)
        {
            items[i].Update();
        }
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
        for (int i = 0; i < items.Count; i++)
        {
            items[i].OnTriggerEnter2D(collision.otherCollider,collision.collider);
        }
    }
   
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].OnTriggerExit2D(collision.otherCollider, collision.collider);
        }
    }
}