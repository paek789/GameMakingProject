using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    float timer;
    [SerializeField]
    GameObject wave;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            Instantiate(wave, this.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            Destroy(gameObject);
        }
    }
}
