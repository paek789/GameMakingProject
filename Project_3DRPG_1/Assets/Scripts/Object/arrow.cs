using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public int damage;
    float timer;
    CapsuleCollider capsule;
    Player player;
    Rigidbody rigid;
    bool isonplayer;
    Vector3 isOnTransform;
    Transform transform_Player;
    


    private void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();
        transform_Player = GameObject.Find("Player").transform;
        isonplayer = false;
        timer = 0;
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5) Destroy(gameObject, 0);
        if (isonplayer)
        {            
            transform.SetParent(player.transform, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "wall" || other.tag == "floor")
        {
            if (!player.isb && other.tag == "Player" && !player.rollImmuneDamage)
            {
                isonplayer = true;
                isOnTransform = new Vector3(transform.position.x - transform_Player.position.x, transform.position.y, transform.position.z - transform_Player.position.z);
                transform.position = isOnTransform;
                rigid.constraints = RigidbodyConstraints.FreezeAll;
                gameObject.GetComponent<TrailRenderer>().enabled = false;
            }
            else if (other.tag == "Player" && player.rollImmuneDamage)
            {

            }
            else rigid.constraints = RigidbodyConstraints.None;

            capsule.isTrigger = false;
        }

    }
}
