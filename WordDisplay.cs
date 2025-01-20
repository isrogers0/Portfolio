using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

	public Text text;
	public float fallSpeed = 1f;
	public AudioSource audioSourceType;
	public AudioSource audioSourceTyped;
	public AudioClip type;
	public AudioClip typed;

	public void SetWord (string word)
	{
		text.text = word;
	}

	public void RemoveLetter ()
	{
		audioSourceType.PlayOneShot(type, 0.5f);
		text.text = text.text.Remove(0, 1);
		text.color = Color.red;
	}

	public void RemoveWord ()
	{
		Word.wordsTyped++;
		audioSourceTyped.PlayOneShot(typed, 0.5f);
		Destroy(gameObject, 2);
	}

	private void Update()
	{
		if (text.rectTransform.localPosition.y <= -400f)
        {
			WordManager.missedWords++;
			Destroy(gameObject);
        }
		transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
	}
}
