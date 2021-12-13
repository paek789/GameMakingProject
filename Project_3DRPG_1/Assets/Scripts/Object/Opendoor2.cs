using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoor2 : MonoBehaviour
{
    public GameObject gameObject1, gameObject2, gameObject3, gameObject4;
    public CameraFollow camerafollow;
    Vector3 doorvec;
    public ParticleSystem fog;
    bool dooropen, dooropen2;
    
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        doorvec = new Vector3(0, 0.003f, 0);
        dooropen = false;
        dooropen2 = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject1 == null && gameObject2 == null && gameObject3 == null && gameObject4 == null && timer < 4)
        {
            transform.position += doorvec;
            timer = Time.deltaTime;
            dooropen = true;
        }
        if(dooropen && dooropen2)
        {
            camerafollow.StartCoroutine(camerafollow.Shake(0.05f, 4f));
            fog.Stop();
            dooropen2 = false;
        }

    }
}
