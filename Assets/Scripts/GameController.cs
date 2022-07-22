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
    
    

   
   

    
    
    //gameOver
    GameObject player;
     GameObject gameOverPanel;

    private void Start()
    {
        
        player = GameObject.Find("Player");
        
       
 
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
        itemSelectMainPanel.GetComponent<SelectItems>().DisplayItems();
        level++;
        Time.timeScale = 0;
        
        

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
