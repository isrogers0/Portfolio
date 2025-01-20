using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {

	public string word;
	private int typeIndex;
	public static int correctLettersTyped = 0;
	public static int wordsTyped = 0;

	WordDisplay display;

	public Word (string _word, WordDisplay _display)
	{
		word = _word;
		typeIndex = 0;

		display = _display;
		display.SetWord(word);
	}

	public char GetNextLetter ()
	{
		return word[typeIndex];
	}

	public void TypeLetter ()
	{
		typeIndex++;
		correctLettersTyped++;
		display.RemoveLetter();
	}

	public bool WordTyped ()
	{
		bool wordTyped = (typeIndex >= word.Length);
		if (wordTyped)
		{
			display.RemoveWord();
		}
		return wordTyped;
	}

}
