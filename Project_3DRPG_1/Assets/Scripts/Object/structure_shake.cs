using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class structure_shake : MonoBehaviour
{
    float a;
    float b;
    float rot;
    bool k;
    bool shake;
    float timer;
    Vector3 curvec;
    // Start is called before the first frame update
    void Start()
    {
        shake = false;
        k = true;
        rot = transform.eulerAngles.z;
        timer = 1f;
        curvec = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        b = transform.eulerAngles.z;
        timer += Time.deltaTime;
        if(timer < 0.3f) {
        if (b > 23) k = true;
        else if (b < 17) k = false;
        if(k)transform.Rotate(0, 0, -0.5f);
        else if(!k)transform.Rotate(0, 0, 0.5f);
        }
        /*
        b = transform.eulerAngles.z;
        timer += Time.deltaTime;
        if (timer < 1f)
        {
            if ((rot + 10) < b)
            {
                k = false;
            }
            else if ((rot - 10) > b) 
            { 
                k = true; 
            }

            if (k)
            {
                transform.Rotate(0, 0, 1f);
            }
            else
            {
                transform.Rotate(0, 0, -1f);
            }
        }
        else
        {
            transform.eulerAngles = curvec;
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword" )
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            shake = true;
            k = true;
            timer = 0;
            

        }
    }
}
