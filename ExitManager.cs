using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public Text wordsTyped;
    public Text lettersTyped;
    public Text correctLettersTyped;
    public Text percentageCorrect;
    public Text username;

    void Start()
    {
        int cL = PlayerPrefs.GetInt("correctLetters");
        int lT = PlayerPrefs.GetInt("lettersTyped");
        wordsTyped.text = PlayerPrefs.GetInt("wordsTyped").ToString();
        lettersTyped.text = lT.ToString();
        correctLettersTyped.text = cL.ToString();
        float temp = Mathf.Round(((float)cL / (float)lT) * 100);
        Debug.Log(temp);
        percentageCorrect.text = temp.ToString() + "%";
    }
    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void exitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
