using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollState_Player : StateMachineBehaviour
{
    Transform playertransform;
    Player player;
    Vector3 rollVec;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
        playertransform = animator.GetComponent<Transform>();
        rollVec = new Vector3(player.hAxis, 0, player.vAxis).normalized;
        player.StartCoroutine("onimmuneDamage");
        player.transform.LookAt(player.transform.position + rollVec);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.transform.position += rollVec * player.speed * 2 * Time.deltaTime;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
