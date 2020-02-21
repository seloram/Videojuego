using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isPaused;
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
            //isPaused = !isPaused;
            
            //Scene s1 = SceneManager.GetSceneByName("Stage_1");
            //Scene s2 = SceneManager.GetSceneByName("MenuScene");

            //SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
            //SceneManager.SetActiveScene(s2);
            GameObject a =  GameObject.FindGameObjectWithTag("Menu");
            a.SetActive(false);
        }
    }
}
