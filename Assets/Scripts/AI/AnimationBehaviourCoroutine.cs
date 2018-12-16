using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehaviourCoroutine : MonoBehaviour {

    public void DoCoroutine(Animator animator, bool isPatrol)
    {
        StartCoroutine(WaitAndChangePatrolling(animator, isPatrol));
    }

    IEnumerator WaitAndChangePatrolling(Animator animator, bool isPatrol)
    {
        yield return new WaitForSeconds(4f);

        animator.SetBool("IsPatrolling", isPatrol);
    }
}
