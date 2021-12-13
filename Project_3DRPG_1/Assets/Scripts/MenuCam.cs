using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCam : MonoBehaviour
{
    Vector3 movevec;
    Vector3 firstvec;
    Vector3 camvec;
    public Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        firstvec = Input.mousePosition / 1000;
        camvec = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        movevec = Input.mousePosition / 1000;
        transform.position = camvec + movevec-firstvec;
    }
}
