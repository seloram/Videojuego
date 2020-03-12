using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InitialParameters : MonoBehaviour
{
    static public float volume;
    static public int quality;
    public AudioMixer sfxVolume;
    public AudioMixer musicVolume;
    public GUISkin customSkin;
    // Start is called before the first frame update
    void Start()
    {
        GameObject warrior3 = GameObject.FindGameObjectWithTag("warrior 2");
        
        if (PressButton.difficulty == 1)
        {
            GameObject warrior2 = GameObject.FindGameObjectWithTag("warrior 2");            
            warrior2.SetActive(false);
        }
        GameObject pause = GameObject.FindGameObjectWithTag("pausePanel");
        pause.transform.localScale = new Vector3(0, 0, 0);
        GameObject animCountDown = GameObject.FindGameObjectWithTag("animCountDown");
        animCountDown.transform.localScale = new Vector3(0, 0, 0);
        //sfxVolume.SetFloat("sfxVolume", GameParameters.sfxVolume);
        
        //AudioListener.volume = PressButton..volume;
        QualitySettings.SetQualityLevel(GameParameters.quality);
    }
    private void OnGUI()
    {
        GUI.skin = customSkin;
        string readout = "CONTROLS: ";
        readout += "\nUP   -> W";
        readout += "\nDOWN -> S";
        readout += "\nLEFT -> A";
        readout += "\nRIGHT-> D";
        readout += "\nJUMP -> SPACE";
        readout += "\nPAUSE-> SCAPE";
        readout += "\nMAIN MENU-> P";

        readout += "\n";


        GUILayout.BeginVertical();
        //GUIStyle style = new GUIStyle(GUI.skin.box);
        //style.alignment = TextAnchor.LowerCenter;
        //GUI.skin.box = style;        
        GUI.Box(new Rect(0, 100, 100, 150), readout);

        if (GUI.Button(new Rect(0, 250, 80, 20), "INMORTAL"))
        {
            RollManager.currentHealth = 100000;
        }
        if (GUI.Button(new Rect(0, 270, 80, 20), "TEST"))
        {
            GameObject.FindGameObjectWithTag("warrior 2").SetActive(false);
            GameObject.FindGameObjectWithTag("warrior").SetActive(false);
        }
        GUILayout.EndVertical();
    }
    // Update is called once per frame
    void Update()
    {
        sfxVolume.SetFloat("sfxVolume", GameParameters.sfxVolume * 100 - 80);
        musicVolume.SetFloat("musicVolume", GameParameters.musicVolume * 100 - 80);
        Debug.Log("initialparameters->sfxvolume" + GameParameters.sfxVolume);
    }
}
