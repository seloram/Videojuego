using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    static public float volume;
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
    
        volume = AudioListener.volume;
        quality = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        b.UpdateQualityLabel();
        b.UpdateVolumeLabel();
    }
}
