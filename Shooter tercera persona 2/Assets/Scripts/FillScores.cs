using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillScores : MonoBehaviour
{
    public Font font;
    public GameObject scoreList;
    string namePlayer;
    bool done = false;
    public GameObject inputNamePlayer;
    // Start is called before the first frame update
    void Start()
    {        
        scoreList.transform.localScale = new Vector3(0, 0, 0);
        //inputNamePlayer = GameObject.FindGameObjectWithTag("inputNamePlayer");
        inputNamePlayer.GetComponent<Animator>().SetBool("Open", true);        
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            //Debug.Log("tamaño" + inputNamePlayer.transform.localScale.ToString());
            //inputNamePlayer.transform.localScale = new Vector3(0, 0, 0);
            //Debug.Log("tamaño" + inputNamePlayer.transform.localScale.ToString());
            inputNamePlayer.GetComponent<Animator>().SetBool("Close", true);
            inputNamePlayer.GetComponent<Animator>().SetBool("Open", false);
            scoreList.GetComponent<Animator>().SetBool("Open", true);
            StartCoroutine(delay());
        }
    }

    public void namesList()
    {
        scoreList.transform.localScale = new Vector3(1, 1, 1);       
        
        namePlayer = GameObject.FindGameObjectWithTag("namePlayer").GetComponent<UnityEngine.UI.Text>().text;
        Debug.Log("11111");
        GameObject nameScore = null;
        GameObject points = null;
        string name = "name_";
        string score = "score_";
        for (int i = 1; i <= 5; i++)
        {
            Debug.Log("22222");
            name += i;
            score += i;
            try
            {
                Debug.Log("3333");
                nameScore = GameObject.FindGameObjectWithTag(name);
                points = GameObject.FindGameObjectWithTag(score);
                if (nameScore.GetComponent<UnityEngine.UI.Text>().text == "")
                {
                    Debug.Log("44444");
                    nameScore.GetComponent<UnityEngine.UI.Text>().text = namePlayer;


                    points.GetComponent<UnityEngine.UI.Text>().text = VictoryManager.score.ToString();
                }
            }
            catch { }
        }        
        Debug.Log("delay antes");
        done = true;
        //StartCoroutine(delay());
        Debug.Log("delay depsues");
    }
    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("delay");
        SceneManager.LoadScene("MenuScene");
    }    
}
