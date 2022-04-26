using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbed_Player : StateMachineBehaviour
{
    Player player;
    Transform bossTransform;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
        bossTransform = GameObject.Find("Boss1").GetComponent<Transform>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.transform.LookAt(bossTransform);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
