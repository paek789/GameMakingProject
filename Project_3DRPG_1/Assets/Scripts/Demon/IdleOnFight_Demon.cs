using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleOnFight_Demon : StateMachineBehaviour
{
    Demon demon;
    int randint1;
    int randint2;
    float distance;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randint1 = Random.Range(1, 3);
        randint2 = Random.Range(1, 4);
        demon = animator.GetComponent<Demon>();
        distance = Vector3.Distance(demon.transform_Player.position, demon.transform.position);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.transform.LookAt(demon.transform_Player);

        if (distance < 2f)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("spell1", false);
            animator.SetBool("spell2", false);
            if (randint1 == 1) animator.SetBool("isCover", true);
            else animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isCover", false);
            animator.SetBool("isJump", false);
            if (randint2 == 1) animator.SetBool("isRun", true);
            else if (randint2 == 2) animator.SetBool("spell1", true);
            else if (randint2 == 3) animator.SetBool("spell2", true);
        }

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
