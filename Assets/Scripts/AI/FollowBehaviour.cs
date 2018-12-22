using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    private Vector2 playerPosition;
    private float stoppingDistance;
    private float runSpeed;

    private void GetValues(Animator animator)
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        stoppingDistance = animator.GetComponent<EnemyAI>().stoppingDistance;
        runSpeed = animator.GetComponent<EnemyAI>().runSpeed;
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetValues(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetValues(animator);

        if (Vector2.Distance(animator.transform.position, playerPosition) > stoppingDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(playerPosition.x, animator.transform.position.y), runSpeed * Time.deltaTime);
        }

        if (playerPosition.x > animator.transform.position.x && animator.GetComponent<EnemyAI>().facingRight)
        {
            animator.GetComponent<EnemyAI>().Flip();
            Debug.Log("Follow1");
        }

        if (playerPosition.x < animator.transform.position.x && !animator.GetComponent<EnemyAI>().facingRight)
        {
            animator.GetComponent<EnemyAI>().Flip();
            Debug.Log("Follow2");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}