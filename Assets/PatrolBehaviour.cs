using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    private float randomSpot;
    private float walkingSpeed;
    private Vector3 startPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startPosition = animator.transform.position;

        walkingSpeed = animator.GetComponent<EnemyAI>().walkingSpeed;     
        randomSpot = Random.Range(animator.GetComponent<EnemyAI>().patrolMin, animator.GetComponent<EnemyAI>().patrolMax);

        animator.GetComponent<AnimationBehaviourCoroutine>().DoCoroutine(animator, false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, new Vector2(startPosition.x + randomSpot, startPosition.y)) > 0.1f)
        {
            animator.transform.position = Vector2.MoveTowards(new Vector2(animator.transform.position.x, 0), new Vector2(startPosition.x + randomSpot, startPosition.y), walkingSpeed * Time.deltaTime);
        }
        else
        {
            walkingSpeed = animator.GetComponent<EnemyAI>().walkingSpeed;            
            randomSpot = Random.Range(animator.GetComponent<EnemyAI>().patrolMin, animator.GetComponent<EnemyAI>().patrolMax);
        }

        if (startPosition.x + randomSpot > animator.transform.position.x && animator.GetComponent<EnemyAI>().facingRight)
        {
            animator.GetComponent<EnemyAI>().Flip();
        }

        if (startPosition.x + randomSpot < animator.transform.position.x && !animator.GetComponent<EnemyAI>().facingRight)
        {
            animator.GetComponent<EnemyAI>().Flip();
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
