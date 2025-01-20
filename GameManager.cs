using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    public int coinsCollected = 0;
    public Text coins;
    public Text health;
    public Text coinsCol;
    public int hp;
    public GameObject pause;
    public GameObject dead;
    [Header("Sound Clips")]
    public AudioClip coin;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "HP: " + hp;
        coins.text = "COINS: " + coinsCollected;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void collectCoin()
    {
        coinsCollected = coinsCollected + 1;
        audioSource.PlayOneShot(coin);
    }
    void PauseGame()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
        pause.SetActive(true);
    }
    public void ResumeGame()
    {
        AudioListener.volume = 1;
        Time.timeScale = 1;
        pause.SetActive(false);
    }
    public void died()
    {
        coinsCol.text = "COINS COLLECTED: " + coinsCollected;
        AudioListener.volume = 0;
        dead.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
    public void quitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
