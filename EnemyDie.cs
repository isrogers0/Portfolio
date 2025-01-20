using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : StateMachineBehaviour
{
    public ParticleSystem smoke;
    public GameObject coin;
    public Vector3 pos, coinPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int count = Random.Range(2, 4);
        int randomCoinX = Random.Range(-1, 1);
        int randomCoinZ = Random.Range(-1, 1);

        Vector3 pos = new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y, animator.gameObject.transform.position.z);
        Vector3 coinPos = new Vector3(animator.gameObject.transform.position.x + randomCoinX, animator.gameObject.transform.position.y, animator.gameObject.transform.position.z + randomCoinZ);
        Instantiate(smoke, pos, Quaternion.identity);

        for (int i = 0; i < count; i++)
        {
            randomCoinX = Random.Range(-1, 1);
            randomCoinZ = Random.Range(-1, 1);
            coinPos = new Vector3(animator.gameObject.transform.position.x + randomCoinX, animator.gameObject.transform.position.y, animator.gameObject.transform.position.z + randomCoinZ);
            Instantiate(coin, coinPos, Quaternion.identity);
        }
        Destroy(animator.gameObject);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
