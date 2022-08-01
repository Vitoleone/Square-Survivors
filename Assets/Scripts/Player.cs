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
    public bool isHearthActive = false;
    public bool isLevelUp = false;
    //Player stats
    public HealthBar healthBar;
    [SerializeField] public float playerMaxHealth;
    [SerializeField] public float playerHealth;
    [SerializeField] public float playerRange;
    [SerializeField] public float playerDamage = 1;
    [SerializeField] public float playerHealthRegen = 0;
    [SerializeField] public float playerHealthRegenRate = 1f;
    //----------------------------
    //Dead effect
    public ParticleSystem deadParticle;
    //exp speed
    float expSpeed = 4.5f;
    //MagicMissle
    public GameObject bullet;

    private void Awake()
    {
        equippedItems.items.Clear();//Oyun baþladýðýnda üzerimizdeki tüm itemleri temizliyoruz
    }

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
        //Player health regen
        playerHealthRegenRate -= Time.deltaTime;
        PlayerHealthRegen();
       
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
    public IEnumerator PlayerHealthRegenDelay()
    {
        yield return new WaitForSeconds(playerHealthRegenRate);
        
    }
    public void PlayerHealthRegen()
    {
        if ((playerHealth + playerHealthRegen) < playerMaxHealth && playerHealthRegenRate <= 0)
        {
            Debug.Log("Player can: " + playerHealthRegen + " arttý.");
            playerHealth += playerHealthRegen;
            healthBar.SetHealth(playerHealth, playerMaxHealth);
            playerHealthRegenRate = 1;
        }
    }

    
   
   
}