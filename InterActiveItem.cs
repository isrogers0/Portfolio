using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActiveItem : MonoBehaviour
{
    public Mesh secondObject;
    public bool isLever;
    public bool isChest;
    public GameObject coin;
    public Vector3 pos, coinPos;
    public scr_animControllerTriggerDemo[] scr_AnimControllerTrigger;
    [Header("Sound Clips")]
    public AudioClip chest;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapObject()
    {
        this.gameObject.GetComponent<MeshFilter>().mesh = secondObject;
        audioSource.PlayOneShot(chest);
        if (isChest)
            chestOpen();
        foreach (scr_animControllerTriggerDemo scr_AnimControllerTrigger in scr_AnimControllerTrigger)
        {
            scr_AnimControllerTrigger.isOn = false;
        }
    }
    public void chestOpen()
    {
        float randomCoinX;
        float randomCoinZ;
        int count = Random.Range(5, 7);

        for (int i = 0; i < count; i++)
        {
            randomCoinX = Random.Range(-3, 3);
            randomCoinZ = Random.Range(-3, 3);
            coinPos = new Vector3(gameObject.transform.position.x + randomCoinX, gameObject.transform.position.y, gameObject.transform.position.z + randomCoinZ);
            Instantiate(coin, coinPos, Quaternion.identity);
        }
    }

}
