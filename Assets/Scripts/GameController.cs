using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{   
    //Exp Values
    public  Text totalExpText;
    public  Text levelText;
    public static int totalExp;
    public Slider expAmountSlider;
    public static int level;
    public int expAmount;
    //Timer Values
    public float seconds;
    public Text timerText;
    [SerializeField] GameObject itemSelectMainPanel;
    [SerializeField] GameObject itemPanel;
    
    [SerializeField] List<Sprite> itemSprites;
    List<Items> itemList;
    
   
   

    
    
    //gameOver
    GameObject player;
     GameObject gameOverPanel;

    private void Start()
    {
        
        player = GameObject.Find("Player");
        //itemselector
        itemList = new List<Items>();
        
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


        //public Garlic()
        //{
        //    cooldown = gCooldown;
        //    damage = gDamage;
        //    area = gArea;
        //    duration = gDuration;
        //    name = "Soðan";
        //    description = "Etrafýndaki alana giren düþmanlara hasar verir.";
        //    itemImage = itemimage.GetComponent<Image>().sprite;
        //    itemLevel = item_Level;
        //}





    }

    private void Update()
    {
        
        seconds += 1*Time.deltaTime;
        Count(seconds);
        GameOverScreen();
    }
    public void addExp(int expAmount)
    {
        if(expAmountSlider.value == expAmountSlider.maxValue)
        {
            expAmountSlider.value = 0;
            totalExp = 0;
            expAmountSlider.maxValue += Mathf.RoundToInt(expAmountSlider.maxValue*1.3f);
            LevelUp();
            
            totalExpText.text = totalExp.ToString();
            levelText.text = "Level:" + level.ToString();
        }
        else 
        {
            totalExp += expAmount;
            expAmountSlider.value = totalExp;
            if (expAmountSlider.value == expAmountSlider.maxValue)
            {
                expAmountSlider.value = 0;
                totalExp = 0;
                expAmountSlider.maxValue += Mathf.RoundToInt(expAmountSlider.maxValue * 1.3f);
                LevelUp();
                totalExpText.text = totalExp.ToString();
                levelText.text = "Level:" + level.ToString();
            }
            totalExpText.text = totalExp.ToString();
            levelText.text = "Level:" + level.ToString();
        }
        
    }
    
 
    void LevelUp()
    {
        int decrease = 0;
        int randomint = 0;
        level++;
        Time.timeScale = 0;
        itemSelectMainPanel.active = true;
            
        for(int i = 0; i < 3; i++)
        {

            randomint = UnityEngine.Random.Range(0, 2);
            GameObject newItemPanel = Instantiate(itemPanel);
            newItemPanel.transform.SetParent(itemSelectMainPanel.transform, true);
            newItemPanel.transform.position = new Vector3(itemSelectMainPanel.transform.position.x, itemSelectMainPanel.transform.position.y - decrease+4.2f, itemSelectMainPanel.transform.position.z);
            newItemPanel.transform.localScale = Vector3.one;
            newItemPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemSprites[randomint];
            newItemPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = itemList[randomint].name;

            newItemPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = itemList[randomint].itemLevel.ToString();
            newItemPanel.transform.GetChild(3).gameObject.GetComponent<Text>().text = itemList[randomint].description;
            decrease += 4;
        }
        
            
       
        
        //newItemPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemList[randomint].
        //for(int satir = 1; satir <= 3;satir++)
        //{
        //    itemSelectMainPanel.transform.GetChild(satir).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemList[randomint].itemImage; //Item Image
        //    itemSelectMainPanel.transform.GetChild(satir).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = itemList[randomint].name; //Item Name
        //    itemSelectMainPanel.transform.GetChild(satir).gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = itemList[randomint].itemLevel.ToString(); //New texti
        //    itemSelectMainPanel.transform.GetChild(satir).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = itemList[randomint].description; //Item description
        //}
       
    }
    void Count(float timeToDisplay)
    {
        float sec = Mathf.FloorToInt(timeToDisplay%60);
        float min = Mathf.FloorToInt(timeToDisplay/60);
        timerText.text = string.Format("{0:00}:{1:00}",min,sec);

    }

    //GameOver Screen
    void GameOverScreen()
    {
        if(player == null)
        {
            StartCoroutine(delay(1.5f));
            
        }
    }
    IEnumerator delay(float delayTime)
    {
        yield return new WaitForSecondsRealtime(delayTime);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }



}
