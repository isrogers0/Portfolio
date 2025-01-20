using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 3;
    public event Action<Player> onPlayerDeath;

    private void Start()
    {
        var color = this.gameObject.GetComponent<Renderer>();
        if (PlayerPrefs.GetInt("PlayerColor") == 0)
        {
            color.material.SetColor("_Color", Color.white);
        }
        if (PlayerPrefs.GetInt("PlayerColor") == 1)
        {
            color.material.SetColor("_Color", Color.blue);
        }
        if (PlayerPrefs.GetInt("PlayerColor") == 2)
        {
            color.material.SetColor("_Color", Color.red);
        }

        Vector3 size;
        if(PlayerPrefs.GetInt("PlayerSize") == 0)
        {
            size = new Vector3(1f, 1f, 1f);
            this.gameObject.transform.localScale = size;
        }
        if (PlayerPrefs.GetInt("PlayerSize") == 1)
        {
            size = new Vector3(0.5f, 0.5f, 0.5f);
            this.gameObject.transform.localScale = size;
        }
        if (PlayerPrefs.GetInt("PlayerSize") == 2)
        {
            size = new Vector3(2f, 2f, 2f);
            this.gameObject.transform.localScale = size;
        }
    }

    void collidedWithEnemy(Enemy enemy)
    {
        enemy.Attack(this);
        if (health <= 0)
        {
            if (onPlayerDeath != null)
            {
                onPlayerDeath(this);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            collidedWithEnemy(enemy);
        }
    }
}
