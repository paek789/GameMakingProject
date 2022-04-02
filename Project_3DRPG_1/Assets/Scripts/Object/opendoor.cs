using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public GameObject blockwall;
    public GameObject door1;
    public CameraFollow camerafollow;
    public ParticleSystem fog;
    
    Vector3 doorvec;
    bool isPlayerArrive;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        doorvec = new Vector3(0, 0.01f, 0);
        isPlayerArrive = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerArrive && timer < 4)
        {
            door1.transform.position += doorvec;
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            Destroy(blockwall, 0);
            isPlayerArrive = true;
            fog.Stop();
            camerafollow.StartCoroutine(camerafollow.Shake(0.05f, 4f));
            Destroy(gameObject, 5);
        }
    }
}
