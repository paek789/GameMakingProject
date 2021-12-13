using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTime : MonoBehaviour
{
    public GameObject attackParticle;
    public Player player;
    Vector3 embervec;
    Vector3 collvec;
    Quaternion emberq;
    
    // Start is called before the first frame update
    void Start()
    {
        embervec = new Vector3(0, 1.5f,0);
        emberq = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Demon" || collision.collider.tag == "Goblin1" || collision.collider.tag == "Boss1")
        collvec = collision.contacts[0].point;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Demon" || other.tag == "Goblin1" || other.tag == "Boss1")
        {
            collvec = other.transform.position;
            StartCoroutine(AttackParticle(collvec));
        }
    }

    IEnumerator AttackParticle(Vector3 collvec)
    { // player.transform.position+ player.transform.forward*1.7f+embervec
        Instantiate(attackParticle, collvec+embervec, player.transform.rotation);
        yield return new WaitForSeconds(2f);
    }
}
