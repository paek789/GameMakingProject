using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    TutorialManager tutorialManager;
    // Start is called before the first frame update
    void Start()
    {
        tutorialManager = GameObject.Find("GameManager").GetComponent<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorialManager.beacon++;
            Destroy(gameObject, 0);
        }
    }
}
