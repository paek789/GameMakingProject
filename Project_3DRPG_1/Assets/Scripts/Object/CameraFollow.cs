using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    Vector3 originPos;

    void Update()
    {
        transform.position = target.position + offset;        
    }
    public IEnumerator Shake(float amount, float duration)
    {
        originPos = transform.position;
        float timer = 0;
        while (timer <= duration)
        {
            transform.position = (Vector3)Random.insideUnitCircle * amount + target.position + offset;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = originPos;

    }
}
