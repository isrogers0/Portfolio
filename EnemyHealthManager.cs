using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    [Header("Health Stats")]
    public int lives = 3;
    [HideInInspector]
    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            enemyController.isDead = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            lives = lives - 1;
        }
    }
}
