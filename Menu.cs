using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{

    public TMP_InputField playerName;
    public Slider playerSpeed;
    public TextMeshProUGUI speed;

    private void Update()
    {
        speed.text = playerSpeed.value.ToString();
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("Username", playerName.text);
        PlayerPrefs.SetFloat("PlayerSpeed", playerSpeed.value);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
