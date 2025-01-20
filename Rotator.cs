using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed;

    private void Start()
    {
        var color = this.gameObject.GetComponent<SpriteRenderer>();
        speed = PlayerPrefs.GetFloat("rotatorSpeed");
        if (PlayerPrefs.GetInt("rotatorColor") == 0)
        {
            color.color = Color.black;
        }
        if (PlayerPrefs.GetInt("rotatorColor") == 1)
        {
            color.color = Color.red;
        }
        if (PlayerPrefs.GetInt("rotatorColor") == 2)
        {
            color.color = Color.blue;
        }
    }

    void Update ()
	{
		transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}

}
