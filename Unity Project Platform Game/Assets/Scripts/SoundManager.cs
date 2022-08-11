using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    [SerializeField] Slider volumeSlider;
    private bool muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Sound Volume"))
        {
            PlayerPrefs.SetInt("Sound Volume", 1);
            Load();
        }
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("Muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
        Save();
        
    }

    public void onButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("Mute") == 1;
        volumeSlider.value = PlayerPrefs.GetFloat("Sound Volume");
    }

    private void Save()
    {
        if (muted == true) { PlayerPrefs.SetInt("Muted", 1); }
        else PlayerPrefs.SetInt("Muted", 0);
        PlayerPrefs.SetFloat("Sound Volume", volumeSlider.value);
    }

    public void ChangeVolume()
    {
        Save();
        AudioListener.volume = volumeSlider.value;
    }
}
