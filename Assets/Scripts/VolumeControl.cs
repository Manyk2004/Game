using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class VolumeControl : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private const float mult = 20f;
    private float volumeValue; 
    
    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        volumeValue = Mathf.Log10(value) * mult;
        mixer.SetFloat(volumeParameter, volumeValue);
    }

    void Start()
    {
        volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * mult);
        slider.value = Mathf.Pow(10f, volumeValue / mult);
    }

    void Update()
    {
        PlayerPrefs.SetFloat(volumeParameter, volumeValue);
    }
}
