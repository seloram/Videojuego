using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PressButton : MonoBehaviour
{
    public GameObject Menu;
    public GameObject SettingsPanel;
    private Animator menuAnim;
    private Animator settingsPanelAnim;
    private void Awake()
    {
        menuAnim = Menu.GetComponent<Animator>();
        settingsPanelAnim = SettingsPanel.GetComponent<Animator>();
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
        SceneManager.LoadScene("Stage_1");
    }
    public void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }else
            Application.Quit();
    }
}
