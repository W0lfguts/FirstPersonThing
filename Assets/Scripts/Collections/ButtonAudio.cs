using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip buttonSelect;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound()
    {
        audio.PlayOneShot(buttonSelect);
    }
}
