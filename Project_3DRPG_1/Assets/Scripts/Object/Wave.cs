using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    float timer;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale += new Vector3(0.02f, 0, 0.02f);
        timer += Time.deltaTime;
        if (timer > 10f) Destroy(gameObject);
    }
}
