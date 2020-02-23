using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialParameters : MonoBehaviour
{
    static public float volume;
    static public int quality;
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
        
        AudioListener.volume = GameParameters.volume;
        QualitySettings.SetQualityLevel(GameParameters.quality);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
