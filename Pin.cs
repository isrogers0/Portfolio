using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	private bool isPinned = false;

	public float speed;
	public Rigidbody2D rb;

    private void Start()
    {
		speed = PlayerPrefs.GetFloat("pinSpeed");
		var color = this.gameObject.GetComponent<SpriteRenderer>();
		if (PlayerPrefs.GetInt("pinColor") == 0)
		{
			color.color = Color.black;
		}
		if (PlayerPrefs.GetInt("pinColor") == 1)
		{
			color.color = Color.red;
		}
		if (PlayerPrefs.GetInt("pinColor") == 2)
		{
			color.color = Color.blue;
		}
	}

    void Update ()
	{
		if (!isPinned)
			rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Rotator")
		{
			transform.SetParent(col.transform);
			Score.PinCount++;
			isPinned = true;
		} else if (col.tag == "Pin")
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}

}
