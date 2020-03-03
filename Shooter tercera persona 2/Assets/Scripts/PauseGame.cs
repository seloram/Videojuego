using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    
    public static bool isPaused;
    private Toggle m_MenuToggle;
    private float mTimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    private bool m_Paused=false;
    public GameObject pauseP;

    void Awake()
    {
        
        m_MenuToggle = GetComponent<Toggle>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
        isPaused = false;
  
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (m_Paused)
            {
                m_Paused = false;
            }
            else
                m_Paused = true;
            
            //Scene s1 = SceneManager.GetSceneByName("Stage_1");
            //Scene s2 = SceneManager.GetSceneByName("MenuScene");
            //SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
            //SceneManager.SetActiveScene(s2);
            MenuOn();
        }
    }

    private void MenuOn()
    {
        
        if (!m_Paused)
        {       
            Time.timeScale = 1f;
            AudioListener.volume = GameParameters.musicVolume;
            pauseP.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {        
            Time.timeScale = 0f;            
            AudioListener.volume = 0f;
            pauseP.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
