using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteor : MonoBehaviour
{
    GameObject asteroid, explosion, meteorRange;
    Material rangeMaterial;
    public int damage;
    Color rangeColor;
    // Start is called before the first frame update
    void Start()
    {
        damage = 20;
        meteorRange = transform.Find("MeteorRange").gameObject;
        asteroid = transform.Find("Asteroid").gameObject;
        explosion = transform.Find("BigExplosion").gameObject;
        rangeMaterial = transform.Find("MeteorRange").GetComponent<MeshRenderer>().material;
        rangeColor = rangeMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        asteroid.transform.position = Vector3.MoveTowards(asteroid.transform.position, transform.position, 10f * Time.deltaTime);
        if(asteroid.transform.position == transform.position)
        {
            asteroid.SetActive(false);
            explosion.SetActive(true);
        }
        if (rangeColor.a > 0.2745f)
        {
            meteorRange.SetActive(false);
            Destroy(gameObject, 3f);
        }
        else
        {
            rangeColor.a += 0.11f * Time.deltaTime;
            rangeMaterial.color = rangeColor;
        }
    }
}
