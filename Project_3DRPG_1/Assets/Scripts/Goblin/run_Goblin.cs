using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run_Goblin : StateMachineBehaviour
{
    Vector3 runvec;
    Goblin goblin;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goblin = animator.GetComponent<Goblin>();
        runvec = (goblin.transform.position - goblin.transform_Player.position).normalized;
        Debug.Log(runvec);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goblin.transform.LookAt(goblin.transform.position + runvec);
        goblin.transform.position += runvec * goblin.speed * 1.5f * Time.deltaTime;
        animator.SetInteger("isClose_goblin", 0);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("isClose_goblin", 0);
    }

}
