using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Vector3 offset;
    public Slider slider;
    public TextMeshProUGUI currentHealth;
    Player Player;
    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = transform.parent.parent.localPosition + offset;
        
        currentHealth.text = ((int)(Player.playerHealth)).ToString();
    }
}
