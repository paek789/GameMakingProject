using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockState_Player : StateMachineBehaviour
{
    Transform playertransform;
    Player player;
    Vector3 clickPos;
    RaycastHit hit;
    Ray ray;
    GameObject sword;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Player>();
        playertransform = animator.GetComponent<Transform>();
        clickPos = Vector3.one;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        sword = GameObject.Find("Sword");
        sword.transform.localEulerAngles = new Vector3(140,0,-25);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics.Raycast(ray, out hit))
        {
            clickPos = hit.point;
            clickPos.y = 0.5f;
        }
        player.isb = true;

        player.transform.LookAt(clickPos);

        if (player.mrUp)
            animator.SetBool("isBlock", false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.isb = false;
        player.rotateVec = player.transform.forward;
        sword.transform.localEulerAngles = new Vector3(200, 70, -25);
    }
}
