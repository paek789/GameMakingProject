using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Demon : StateMachineBehaviour
{
    Demon demon;
    Vector3 jumpvec;
    Vector3 jumpmovevec;
    float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon = animator.GetComponent<Demon>();
        jumpvec = new Vector3(0,3f,0);
        timer = 0;
        jumpmovevec = (demon.transform_Player.position- demon.transform.position).normalized;
        jumpmovevec.y = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        demon.transform.LookAt(demon.transform_Player);
        timer += Time.deltaTime;
        if (timer > 0.5f && timer < 1.4f)
        {
            demon.transform.position += jumpvec * 3 * Time.deltaTime;
        }
        if (timer > 0.5f && timer < 1.8f)
        {
            demon.transform.position += -1 * jumpmovevec * 10 * Time.deltaTime;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.SetBool("isJump", false);
    }
}
