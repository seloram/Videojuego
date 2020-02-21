using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PressButton : MonoBehaviour
{
    public GameObject Menu;
    public GameObject SettingsPanel;
    public GameObject VolumePanel;
    private Animator menuAnim;
    private Animator settingsPanelAnim;
    private Animator menuVolume;
    private void Awake()
    {
        menuAnim = Menu.GetComponent<Animator>();
        settingsPanelAnim = SettingsPanel.GetComponent<Animator>();
        menuVolume = VolumePanel.GetComponent<Animator>();
        //SettingsPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        settingsPanelAnim.SetBool("Open", false);
        settingsPanelAnim.SetBool("Close", true);
        menuAnim.SetBool("Close", false);
        menuAnim.SetBool("Open", true);        
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
        menuVolume.SetBool("Open", true);
    }
}
