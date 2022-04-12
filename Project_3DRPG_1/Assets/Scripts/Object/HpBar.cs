using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Transform cameraTransform;
    Transform target_trans;
    Camera cam;
    public Image hpBar;
    public Image hpBar_m;
    bool ishit = false;

    float health;
    float val;
    // Start is called before the first frame update
    void Start()
    {
        val = 1f;
        cam = Camera.main;
        target_trans = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.WorldToScreenPoint(target_trans.position + new Vector3(0f,1.5f,0));

        if (val > health)
        {
            val -= 0.001f;
        }
        hpBar.rectTransform.localScale = new Vector3(health, 1f, 1f);
        hpBar_m.rectTransform.localScale = new Vector3(val, 1f, 1f);
    }

    public void HealthEffect(float curhealth)
    {
        health = curhealth;
    }
    public void GetTransform(Transform transform)
    {
        target_trans = transform;
    }
    
}
