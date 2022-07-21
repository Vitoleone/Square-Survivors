using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //itemlar ile etkileþim
    public EquippedItems equippedItems;

    //Walking values
    [SerializeField] float playerSpeed;
    [SerializeField] float playerMaxHealth;
    [SerializeField] float playerHealth;
    //Movement
    float horizontalInput;
    float verticalInput;

    public HealthBar healthBar;
    //----------------------------
    //DeadParticle
    public ParticleSystem deadParticle;
    


    void Start()
    {
        
       
        
        //HealthBar
        playerHealth = playerMaxHealth;
        healthBar.SetHealth(playerHealth, playerMaxHealth);
        //shoot   
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //Walking
         horizontalInput = Input.GetAxis("Horizontal");
         verticalInput = Input.GetAxis("Vertical");
       
        PlayerWalk();
        //Walking Ends

        


    
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
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var item = collision.GetComponent<Item>();//item ekleme
    //    if(item)
    //    {
    //        equippedItems.AddItem(item,1);
    //        Destroy(collision.gameObject);
    //    }
    //}
    private void OnApplicationQuit()
    {
        //equippedItems.items.Clear();//uygulamadan çýktýðýmýzda mevcut itemleri silme
    }


    void PlayerWalk()
    {
        transform.Translate(Vector3.right * horizontalInput * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * playerSpeed * Time.deltaTime);

    }
}