using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Transform cameraTransform;
    public Transform target_trans;
    public Goblin goblin;
    public Image hpBar;
    public Image hpBar_m;
    float val;
    // Start is called before the first frame update
    void Start()
    {
        val = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform = Camera.main.transform;
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
        transform.position = target_trans.position;

        if(val>(float)goblin.curHealth/ (float)goblin.maxHealth)
        {
            val -= 0.001f;
        }
        hpBar.rectTransform.localScale = new Vector3((float)goblin.curHealth / (float)goblin.maxHealth, 1f, 1f);
        hpBar_m.rectTransform.localScale = new Vector3(val, 1f, 1f);
    }
}
