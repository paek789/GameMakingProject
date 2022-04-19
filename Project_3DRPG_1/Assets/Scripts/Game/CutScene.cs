using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public PlayableDirector playableDirector;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
