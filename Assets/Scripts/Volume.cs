using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public AudioSource menubong;
    public AudioSource click;

    public void VolumeController()
    {
        volumeAudio.volume = volumeSlider.value;
    }
    public void Menubong()
    {
        menubong.Play();
        menubong.pitch++;
    }
    public void Click()
    {
        click.Play();
    }
}
