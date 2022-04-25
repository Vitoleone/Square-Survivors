using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGain : MonoBehaviour
{
    GameObject gameController;
    [SerializeField] int expAmount;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameController.GetComponent<GameController>().addExp(expAmount);
            Destroy(gameObject);
        }
    }
}
