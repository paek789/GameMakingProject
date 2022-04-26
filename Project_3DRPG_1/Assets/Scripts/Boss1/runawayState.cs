using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runawayState : StateMachineBehaviour
{
    Transform boss1Transform;
    Vector3 moveVec;
    Boss1 boss1;
    float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
        boss1.speed *= 2;
        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveVec = new Vector3(boss1.player.position.x * -1, 0, boss1.player.position.z * -1).normalized;
        boss1Transform.LookAt(boss1.transform.position+ moveVec);
        timer += Time.deltaTime;
        if (timer < 2)
            boss1Transform.position += moveVec * boss1.speed * Time.deltaTime;
        else
            animator.SetBool("isRunaway", false);

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1.runAwayCooltime = 5;
        boss1.StartCoroutine("RunAwayCoolDown");
        timer = 0;
        boss1.speed /= 2;
    }

}
