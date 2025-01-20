using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    public Transform target;
    public float targetDistance;
    public float followDistance;
    public float attackDistance;
    [HideInInspector]
    public float velocity;
    [HideInInspector]
    public bool canMove;
    [HideInInspector]
    public float moveSpeed;
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    [HideInInspector]
    public GameObject activeModel;
    [HideInInspector]
    public bool isDead = false;
    private AudioSource audioSource;
    [Header("Sound Clips")]
    public AudioClip slash;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        canMove = true;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetupAnimator();
    }

    void SetupAnimator()//Setting up Animator component in the hierarchy.
    {
        if (activeModel == null)
        {
            anim = GetComponentInChildren<Animator>();//Find animator component in the children hierarchy.
            if (anim == null)
            {
                Debug.Log("No model");
            }
            else
            {
                activeModel = anim.gameObject; //save this gameobject as active model.
            }
        }

        if (anim == null)
            anim = activeModel.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        velocity = agent.velocity.magnitude / agent.speed;
        moveSpeed = Mathf.Clamp01(velocity);
        followDistance = Vector3.Distance(transform.position, target.transform.position);
        if(followDistance <= targetDistance)
        {
            if (canMove)
            {
                moveEnemy();
            }
        }
        handleMovementAnim();
        if (followDistance <= attackDistance)
        {
            canMove = false;
            attack();
        }
        if (followDistance > attackDistance)
        {
            canMove = true;
            anim.SetBool("attack", false);
            anim.SetBool("altAttack", false);
        }
        if (isDead)
            enemeyDie();
    }

    public void moveEnemy()
    {
        agent.destination = target.position;
    }

    public void attack()
    {
        int randomAttack = Random.Range(1, 2);
        if(randomAttack == 1)
        {
            anim.SetBool("attack", true);
        }
        if (randomAttack == 2)
        {
            anim.SetBool("altAttack", true);
        }
    }

    public void handleMovementAnim()
    {
        anim.SetFloat("moveSpeed", moveSpeed, 0.2f, Time.deltaTime);
    }

    public void enemeyDie()
    {
        canMove = false;
        anim.SetBool("isDead", true);
    }
}
