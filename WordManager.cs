using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {

	public List<Word> words;

	public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;
	public static int lettersTyped = 0;
	public static int missedWords = 0;
	public Text firstX;
	public Text secondX;
	public Text thirdX;

	public void Update()
    {
		if (missedWords == 1)
			firstX.color = Color.red;
		if (missedWords == 2)
			secondX.color = Color.red;
		if (missedWords == 3)
			thirdX.color = Color.red;
		if (missedWords >= 3)
        {
			PlayerPrefs.SetInt("lettersTyped", lettersTyped);
			PlayerPrefs.SetInt("wordsTyped", Word.wordsTyped);
			PlayerPrefs.SetInt("correctLetters", Word.correctLettersTyped);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
		words.Add(word);
	}

	public void TypeLetter (char letter)
	{
		lettersTyped++;
		if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();
			}
		} else
		{
			foreach(Word word in words)
			{
				if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
		}
	}

}
