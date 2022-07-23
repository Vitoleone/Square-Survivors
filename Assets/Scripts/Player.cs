using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //itemlar ile etkileþim
    public EquippedItems equippedItems;

    //Walking values
    [SerializeField] float playerSpeed;
    
    //Movement
    float horizontalInput;
    float verticalInput;
    public float xBound;
    public float yBound1,yBound2;
    //Player status
    public HealthBar healthBar;
    [SerializeField] public float playerMaxHealth;
    [SerializeField] public float playerHealth;
    [SerializeField] public float playerRange;
    //----------------------------
    //Dead effect
    public ParticleSystem deadParticle;
    //exp speed
    float expSpeed = 4.5f;
    


    void Start()
    {


        
        //HealthBar
        playerHealth = playerMaxHealth;
        healthBar.SetHealth(playerHealth, playerMaxHealth);
        //shoot   
       
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        //Walking
        if(transform.position.x > xBound)
        {
            transform.position = new Vector2(xBound, transform.position.y);
        }
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector2(-xBound, transform.position.y);
        }
        if (transform.position.y < yBound1)
        {
            transform.position = new Vector2(transform.position.x, yBound1);
        }
        if (transform.position.y > yBound2)
        {
            transform.position = new Vector2(transform.position.x, yBound2);
        }
        else
        {
            PlayerWalk();
        }



        //Walking Ends


        //Exp Pulling
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, playerRange);
        foreach(Collider2D col in colliders)
        {
            if(col.CompareTag("Exp"))
            {
                col.GetComponent<Transform>().Translate((transform.position - col.transform.position) * Time.deltaTime*expSpeed);
                
            }
        }

    
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, playerRange);
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
   
    private void OnApplicationQuit()
    {
        equippedItems.items.Clear();//uygulamadan çýktýðýmýzda mevcut itemleri silme
    }


    void PlayerWalk()
    {
        transform.Translate(Vector3.right.normalized * horizontalInput * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up.normalized * verticalInput * playerSpeed * Time.deltaTime);

    }
}