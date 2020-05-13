using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    static public float volume;
    static public float sfxVolume = 1.0f;
    static public float musicVolume = 1.0f;
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
        Debug.Log("Gameparameters" + sfxVolume.ToString());
        musicVolume = PressButton.musicVolume;

        quality = QualitySettings.GetQualityLevel();
        UnityEngine.UI.Slider[] s = GameObject.FindObjectsOfType<UnityEngine.UI.Slider>();
        Debug.Log("el volumen musica es: " + musicVolume.ToString());
        foreach (UnityEngine.UI.Slider sli in s)
        {
            if (sli.name == "SliderVolume")
            {
                Debug.Log("el volumen musica es: " + musicVolume.ToString());
                sli.value = PressButton.musicVolume;
            }
            if (sli.name == "SliderSFX")
            {
                sli.value = PressButton.sfxVolume;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        sfxVolume = PressButton.sfxVolume;
        musicVolume = PressButton.musicVolume;
        b.UpdateQualityLabel();
        b.UpdateVolumeLabel();
        b.UpdateSFXVolumeLabel();
    }
}
