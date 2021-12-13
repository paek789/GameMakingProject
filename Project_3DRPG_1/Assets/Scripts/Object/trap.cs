using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public ParticleSystem particle1, particle2, particle3, particle4, particle5, particle6, particle7, particle8, particle9;
    public int damage;
    BoxCollider collider;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3 && timer < 3.04f)
        {
            collider.enabled = true;
            particle1.Play(); particle2.Play(); particle3.Play(); particle4.Play(); particle5.Play(); particle6.Play(); particle7.Play(); particle8.Play(); particle9.Play();
        }
        else if (timer < 3)
        {
            collider.enabled = false;
            particle1.Stop(); particle2.Stop(); particle3.Stop(); particle4.Stop(); particle5.Stop(); particle6.Stop(); particle7.Stop(); particle8.Stop(); particle9.Stop();
        }
        else if (timer > 5) timer = 0;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            collider.enabled = false;
        }
    }
}
