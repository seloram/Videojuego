using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PressButton : MonoBehaviour
{
    static public int difficulty;
    static public float sfxVolume=1.0f;
    static public float musicVolume = 1.0f;
    public GameObject Menu;
    public AudioMixer audioMixer;
    public GameObject SettingsPanel;
    public GameObject VolumePanel;
    public GameObject ResolutionPanel;
    public GameObject DifficultyPanel;
    private Animator menuAnim;
    private Animator settingsPanelAnim;
    private Animator menuVolume;
    private Animator menuResolution;
    private Animator menuDifficulty;
    private void Awake()
    {
        
        menuAnim = Menu.GetComponent<Animator>();
        settingsPanelAnim = SettingsPanel.GetComponent<Animator>();
        menuVolume = VolumePanel.GetComponent<Animator>();
        menuResolution = ResolutionPanel.GetComponent<Animator>();
        menuDifficulty = DifficultyPanel.GetComponent<Animator>();
        //SettingsPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject volM = GameObject.FindGameObjectWithTag("volumeInternalPanel");
        volM.transform.Find("pMusicVolume").GetComponentInChildren<Text>().GetComponentInChildren<UnityEngine.UI.Text>().text = "Music Volume: 100%";       
        
        GameObject volS = GameObject.FindGameObjectWithTag("sfxInternalPanel");
        volS.transform.Find("pSfxVolume").GetComponentInChildren<Text>().GetComponentInChildren<UnityEngine.UI.Text>().text = "SFX Volume: 100%";       
        UnityEngine.UI.Slider[] s = GameObject.FindObjectsOfType<UnityEngine.UI.Slider>();

        foreach (UnityEngine.UI.Slider sli in s)
        {
            if (sli.name == "SliderVolume")
            {
                sli.value = musicVolume;
            }
            if (sli.name == "SliderSFX")
            {
                sli.value = sfxVolume;
            }
        }
    }

    // Update is called once per frame
    void Update()   
    {
        UpdateVolumeLabel();
        UpdateSFXVolumeLabel();
    }
    public void Settings()
    {
        //SettingsPanel.SetActive(true);
        menuAnim.SetBool("Close", true);
        menuAnim.SetBool("Open", false);
        settingsPanelAnim.SetBool("Open", true);
        settingsPanelAnim.SetBool("Close", false);
    }

    public void CloseSettings()
    {
        CloseSubPanels();
        settingsPanelAnim.SetBool("Open", false);
        settingsPanelAnim.SetBool("Close", true);
        menuAnim.SetBool("Close", false);
        menuAnim.SetBool("Open", true);       

        //var newPreviouslySelected = EventSystem.current.currentSelectedGameObject.GetComponentInParent<RectTransform>();
        //Animator[] gas = ga.GetComponentsInChildren<Animator>();
        //Debug.Log(gas.Length);
        //foreach(Animator g in gas)
        //{
        //    if (g.GetComponent<Animator>().GetBool(1))
        //    {
        //        g.SetBool(0, true);
        //    }
        //    Debug.Log("nombre animator: "+g.GetComponent<Animator>().name);            
        //}
        //GameObject go = null;
        //var selectables = ga.GetComponentsInChildren<Selectable>(true);
        //foreach (var selectable in selectables)
        //{
        //    if (selectable.IsActive() && selectable.IsInteractable())
        //    {
        //        go = selectable.gameObject;
        //        Debug.Log(go.name);
        //        break;
        //    }
        //}
    }

    public void CloseSubPanels()
    {
        GameObject ga = GameObject.FindGameObjectWithTag("subPanels");
        var a = ga.GetComponentsInChildren<Animator>(true);
        Debug.Log("longitud" + a.Length);
        foreach (var b in a)
        {
            Debug.Log("nombres dddd: " + b.name);
            Debug.Log("nombres dddd: " + b.GetBool("Open").ToString());
            if (b.GetBool("Open"))
            {
                Debug.Log("ha entrado");
                b.SetBool("Close", true);
                b.SetBool("Open", false);
            }
        }
    }

    public void Resolution()
    {
        CloseSubPanels();
        Debug.Log("resolution in progress");
        menuResolution.SetBool("Close", false);
        menuResolution.SetBool("Open", true);
    }
    public void PlayScene()
    {
        if (SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene("Stage_1");
        }else
        {         
            SceneManager.UnloadScene(SceneManager.GetSceneByBuildIndex(0));
        }
    }
    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }else
            Application.Quit();
    }
    public void Volume()
    {
        CloseSubPanels();
        menuVolume.SetBool("Close", false);
        menuVolume.SetBool("Open", true);       
    }
    public void Difficulty()
    {
        CloseSubPanels();
        menuDifficulty.SetBool("Close", false);
        menuDifficulty.SetBool("Open", true);
    }
    public void SetVolume(float value)
    {        
        musicVolume = value;
        UpdateVolumeLabel();        
    }

    public void DecreaseQuality()
    {
        QualitySettings.DecreaseLevel();
        UpdateQualityLabel();
    }

    public void IncreaseQuality()
    {
        QualitySettings.IncreaseLevel();
        UpdateQualityLabel();
    }

    public void UpdateQualityLabel()
    {
        GameParameters.quality = QualitySettings.GetQualityLevel();
        int currentQuality = QualitySettings.GetQualityLevel();
        string qualityName = QualitySettings.names[currentQuality];
        GameObject res = GameObject.FindGameObjectWithTag("panelResolution");
        res.transform.Find("tResolution").GetComponent<UnityEngine.UI.Text>().text = "Actual Graphics Quality " + qualityName;
    }

    public void UpdateVolumeLabel()
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("musicVolume", GameParameters.musicVolume * 100 - 100);
        }
        
        float audioVolume = musicVolume * 100;
        GameObject vol = GameObject.FindGameObjectWithTag("volumeInternalPanel");        
        vol.transform.Find("pMusicVolume").GetComponentInChildren<Text>().GetComponent<UnityEngine.UI.Text>().text = "Music Volume: " +audioVolume.ToString("f1") + "%";
    }
    public void UpdateSFXVolumeLabel()
    {       
        float audioVolume = sfxVolume * 100;
        GameObject vol = GameObject.FindGameObjectWithTag("sfxInternalPanel");
        vol.transform.Find("pSfxVolume").GetComponentInChildren<Text>().GetComponent<UnityEngine.UI.Text>().text = "SFX Volume: " + audioVolume.ToString("f1") + "%";
    }

    public void SetSfxVolume(float value)
    {        
        sfxVolume = value;
        UpdateSFXVolumeLabel();
    }

    public void Easy()
    {
        difficulty = 1;
    }
    public void Normal()
    {
        difficulty = 2;
    }
    public void Hard()
    {
        difficulty = 3;
    }
}
