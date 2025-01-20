using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{

    public GameObject[] gates;
    public bool playerPresent;
    public bool enemyPresent;
    public bool gateOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] skeletons;
        skeletons = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in skeletons)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                enemyPresent = true;
            }
        }
        if (skeletons.Length == 0)
        {
            enemyPresent = false;
        }
        if (enemyPresent && playerPresent)
        {
            gateOpen = false;
            foreach (GameObject gate in gates)
            {
                gate.GetComponent<Animator>().SetBool("gateOpen", gateOpen);
            }
        } else
        {
            gateOpen = true;
            foreach (GameObject gate in gates)
            {
                gate.GetComponent<Animator>().SetBool("gateOpen", gateOpen);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPresent = true;
        } else
        {
            playerPresent = false;
        }
    }
}
