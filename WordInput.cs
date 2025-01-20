using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour {

	public WordManager wordManager;
    public GameObject pause;

    void Update () {
        if (!pause.activeInHierarchy)
        {
            foreach (char letter in Input.inputString)
            {
                wordManager.TypeLetter(letter);
            }
        }
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
    void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
}
