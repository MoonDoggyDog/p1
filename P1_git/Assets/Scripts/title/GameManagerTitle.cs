using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTitle : MonoBehaviour
{
    AudioSource camAudio;

    public bool isPlayaple = false;

    public GameObject buttonStart;
    public GameObject camForAudio;
    // Update is called once per frame
    void Update()
    {
        if(isPlayaple)
        {
            buttonStart.SetActive(true);
            camAudio = camForAudio.GetComponent<AudioSource>();
            camAudio.Play();
            isPlayaple = false;
        }
    }
}
