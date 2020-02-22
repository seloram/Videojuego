using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PressButton : MonoBehaviour
{
    public GameObject Menu;
    public GameObject SettingsPanel;
    public GameObject VolumePanel;
    public GameObject ResolutionPanel;
    private Animator menuAnim;
    private Animator settingsPanelAnim;
    private Animator menuVolume;
    private Animator menuResolution;
    private void Awake()
    {
        menuAnim = Menu.GetComponent<Animator>();
        settingsPanelAnim = SettingsPanel.GetComponent<Animator>();
        menuVolume = VolumePanel.GetComponent<Animator>();
        menuResolution = ResolutionPanel.GetComponent<Animator>();
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
}
