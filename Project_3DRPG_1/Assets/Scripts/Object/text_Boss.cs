using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_Boss : MonoBehaviour
{
    public Boss1 boss1;
    public TextMeshPro healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = boss1.curHealth.ToString();
    }
}
