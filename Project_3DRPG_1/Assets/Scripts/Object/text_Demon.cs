using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_Demon : MonoBehaviour
{
    public Demon demon;
    public TextMeshPro healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = demon.curHealth.ToString();
    }
}
