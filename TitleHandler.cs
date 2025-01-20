using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class TitleHandler : MonoBehaviour
{
    public Button start;
    public Button next;
    public Button exit;
    public TMP_Dropdown character;
    public TMP_Dropdown weapon;
    public TMP_Dropdown armor;
    public TMP_Dropdown shield;
    public Canvas titleScreen;
    public Canvas characterScreen;
    public GameObject model;
    private bool isCS = false;
    [Header("Model Pieces")]
    public GameObject[] head;
    public GameObject[] body;
    public GameObject[] shields;
    public GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCS)
        {
            model.gameObject.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }
        //Debug.Log(character.value);

        int whichHead = character.value;
        for (int i = 0; i < head.Length; i++)
        {
            if (i == whichHead)
            {
                head[i].SetActive(true);
            }
            else
            {
                head[i].SetActive(false);
            }
        }
        int whichWeapon = weapon.value;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == whichWeapon)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
        int whichBody = armor.value;
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
        int whichShield = shield.value;
        for (int i = 0; i < shields.Length; i++)
        {
            if (i == whichShield)
            {
                shields[i].SetActive(true);
            }
            else
            {
                shields[i].SetActive(false);
            }
        }
    }
    public void toCharacterSelection()
    {
        isCS = true;
        titleScreen.gameObject.SetActive(false);
        characterScreen.gameObject.SetActive(true);
        model.SetActive(true);
    }
    public void exitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void startGame()
    {
        PlayerPrefs.SetInt("Character", character.value);
        PlayerPrefs.SetInt("Weapon", weapon.value);
        PlayerPrefs.SetInt("Armor", armor.value);
        PlayerPrefs.SetInt("Shield", shield.value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
