using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int lives = 100;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.hp = lives;
        if(lives <= 0)
        {
            PlayerDie();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            HurtPlayer(50);
        }
        if (collision.gameObject.CompareTag("Killbox"))
        {
            HurtPlayer(100);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EnemyWeapon"))
        {
            HurtPlayer(1);
            WaitForSecondsRealtime(1);
        }
    }

    private void WaitForSecondsRealtime(int v)
    {
        
    }

    public void HurtPlayer(int damage)
    {
        lives = lives - damage;
    }

    public void PlayerDie()
    {
        gameManager.died();
    }
}
