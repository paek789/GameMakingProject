using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkState_Player : StateMachineBehaviour
{
    Transform playertransform;
    Player player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
        playertransform = animator.GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player.vDown && !player.hDown)
            animator.SetBool("isWalk", false);
        if (player.mlDown)
            animator.SetTrigger("doAttack");
        if (player.mrDown)
            animator.SetBool("isBlock", true);
        if (player.spaceDown)
            animator.SetTrigger("doRoll");


        player.moveVec = new Vector3(player.hAxis, 0, player.vAxis).normalized;

        if(player.moveVec != Vector3.zero) Rotate();


        player.transform.LookAt(player.transform.position + player.rotateVec);

        player.transform.position += player.moveVec * player.speed * Time.deltaTime;

        animator.SetBool("isWalk", player.moveVec != Vector3.zero);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.rotateVec = new Vector3(0, 0, 0);
    }

    public void Rotate()
    {
        if (player.rotateVec.x < player.moveVec.x)
        {
            player.rotateVec.x += 0.035f;
        }
        if (player.rotateVec.x > player.moveVec.x)
        {
            player.rotateVec.x -= 0.035f;
        }
        if (player.rotateVec.z < player.moveVec.z)
        {
            player.rotateVec.z += 0.035f;
        }
        if (player.rotateVec.z > player.moveVec.z)
        {
            player.rotateVec.z -= 0.035f;
        }
    }
}
