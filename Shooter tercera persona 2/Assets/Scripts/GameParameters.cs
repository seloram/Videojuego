using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    static public float volume;
    static public float sfxVolume;
    static public int quality;
    PressButton b;
    private void Awake()
    {
        b = new PressButton();

        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject vol = GameObject.FindGameObjectWithTag("volumeInternalPanel");
        GameObject res = GameObject.FindGameObjectWithTag("panelResolution");
        GameObject sfx = GameObject.FindGameObjectWithTag("sfxInternalPanel");
        sfxVolume = PressButton.sfxVolume;
        
        volume = AudioListener.volume;

        quality = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        sfxVolume = PressButton.sfxVolume;
        
        b.UpdateQualityLabel();
        b.UpdateVolumeLabel();
        b.UpdateSFXVolumeLabel();
    }
}
