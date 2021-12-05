using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack3State : StateMachineBehaviour
{
    Transform boss1Transform;
    Boss1 boss1;
    Material mat;
    Material mat2;
    MeshRenderer mesh;
    MeshRenderer mesh2;
    BoxCollider meleeAttack;
    BoxCollider meleeAttack2;
    public ParticleSystem attack3Particle;
    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
        meleeAttack = GameObject.Find("MeleeAttackRange").GetComponent<BoxCollider>();
        meleeAttack2 = GameObject.Find("MeleeAttackRange2").GetComponent<BoxCollider>();
        mat = GameObject.Find("MeleeAttackRange").GetComponent<MeshRenderer>().material;
        mat2 = GameObject.Find("MeleeAttackRange2").GetComponent<MeshRenderer>().material;
        mesh = GameObject.Find("MeleeAttackRange").GetComponent<MeshRenderer>();
        mesh2 = GameObject.Find("MeleeAttackRange2").GetComponent<MeshRenderer>();
        attack3Particle = GameObject.Find("EarthShatter").GetComponent<ParticleSystem>();
        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer < 1.7f)
        {
            mat.color = Color.red;
            mesh.enabled = true;
        }
        else mesh.enabled = false;
        if (timer > 1.7f && timer < 2.7f)
        {
            mat2.color = Color.red;
            mesh2.enabled = true;
        }
        else mesh2.enabled = false;

        if (timer > 0.9f && timer < 1f) meleeAttack.enabled = true;
        else if (timer > 1.65f && timer < 1.75f) meleeAttack.enabled = true;
        else meleeAttack.enabled = false;

        if (timer > 2.6f && timer < 2.7f) 
        {
            meleeAttack2.enabled = true;
            attack3Particle.Play();
        } 
        else meleeAttack2.enabled = false;








        animator.SetBool("isAttack3", false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attack3Particle.Stop();
    }

}
