using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStart : MonoBehaviour
{
    public GameObject[] head;
    public GameObject[] body;
    public GameObject[] shield;
    public GameObject[] weapon;
    // Start is called before the first frame update
    void Start()
    {
        int whichHead = PlayerPrefs.GetInt("Character");
        for (int i = 0; i < head.Length; i++)
        {
            if(i == whichHead)
            {
                head[i].SetActive(true);
            } else
            {
                head[i].SetActive(false);
            }
        }
        int whichWeapon = PlayerPrefs.GetInt("Weapon");
        for (int i = 0; i < weapon.Length; i++)
        {
            if (i == whichWeapon)
            {
                weapon[i].SetActive(true);
            }
            else
            {
                weapon[i].SetActive(false);
            }
        }
        int whichBody = PlayerPrefs.GetInt("Armor");
        for (int i = 0; i < body.Length; i++)
        {
            if (i == whichBody)
            {
                body[i].SetActive(true);
            }
            else
            {
                body[i].SetActive(false);
            }
        }
        int whichShield = PlayerPrefs.GetInt("Shield");
        for (int i = 0; i < shield.Length; i++)
        {
            if (i == whichShield)
            {
                shield[i].SetActive(true);
            }
            else
            {
                shield[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
