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
    public AudioSource ambience;
    public AudioSource lastStance;
    private float m_VolumeRef = 1f;
    private bool m_Paused=false;
    public GameObject pauseP;
    static public bool ambiencePlaying = false;
    static public bool lastStancePlaying = false;
    void Awake()
    {
        
        m_MenuToggle = GetComponent<Toggle>();
        ambience = GameObject.FindGameObjectWithTag("ambience").GetComponent<AudioSource>();
        lastStance = GameObject.FindGameObjectWithTag("lastStance").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
        isPaused = false;
  
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Escape) && (SceneManager.GetActiveScene().name != "MenuScene") && 
            (int.Parse(GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text) > 0))
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
        if (Input.GetKeyUp(KeyCode.P) && (!m_Paused) && (SceneManager.GetActiveScene().name != "MenuScene") &&
            (int.Parse(GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text) > 5))
        {            
            Time.timeScale = 0f;
            if (ambience.isPlaying)
            {
                ambience.Stop();
                ambiencePlaying = true;
            }
            
            if (lastStance.isPlaying)
            {
                lastStance.Stop();
                lastStancePlaying = true;
            }           
            
            SceneManager.LoadSceneAsync("MenuScene");
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
