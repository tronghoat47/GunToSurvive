using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundSound : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] Slider volumeSlider;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }


    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void StopSound()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
        else
        {
            source.Play();
        }
    }
}
