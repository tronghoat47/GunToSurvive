using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSFX : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.pitch = Random.Range(0.8f, 2.3f);
        source.Play();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }


}
