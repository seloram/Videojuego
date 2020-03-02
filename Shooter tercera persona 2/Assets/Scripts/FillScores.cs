using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;


public class FillScores : MonoBehaviour
{
    string path, jsonstring;

    public BD_Score bdScore;
    public Font font;
    string scoresFile = "";
    List<BD_Score> classScore;
    public GameObject scoreList;
    string namePlayer;
    bool done = false;
    public GameObject inputNamePlayer;
    // Start is called before the first frame update
    void Start()
    {



        classScore = new List<BD_Score>();
        bdScore = new BD_Score();
        ReadJson();
        scoreList.transform.localScale = new Vector3(0, 0, 0);
        //inputNamePlayer = GameObject.FindGameObjectWithTag("inputNamePlayer");
        inputNamePlayer.GetComponent<Animator>().SetBool("Open", true);

        //scoresFile = PlayerPrefs.GetString("scores");
        //Debug.Log("scoresfileinicial" + scoresFile);
        //bdScore = JsonUtility.FromJson<BD_Score>(scoresFile);

    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            //Debug.Log("tamaño" + inputNamePlayer.transform.localScale.ToString());
            //inputNamePlayer.transform.localScale = new Vector3(0, 0, 0);
            //Debug.Log("tamaño" + inputNamePlayer.transform.localScale.ToString());
            WriteJson();
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

        bdScore.name = namePlayer;
        bdScore.points = VictoryManager.score.ToString();

        classScore.Add(bdScore);
        Debug.Log("cuenta"+classScore.Count);
        Debug.Log("bdscore" + bdScore.name);
        Debug.Log("bdscore" + bdScore.points);
        //scoresFile= JsonUtility.ToJson(bdScore);
        //PlayerPrefs.SetString("scores", scoresFile);


        GameObject nameScore = null;
        GameObject points = null;
        string name = "name_";
        string score = "score_";
        for (int i = 1; i <= 5; i++)
        {

            name += i;
            score += i;
            try
            {
                //scoresFile = PlayerPrefs.GetString("scores");
                //bdScore = JsonUtility.FromJson<BD_Score>(scoresFile);
                nameScore = GameObject.FindGameObjectWithTag(name);
                points = GameObject.FindGameObjectWithTag(score);
                Debug.Log("bdscore2" + bdScore.name);
                Debug.Log("bdscore2" + bdScore.points);
                nameScore.GetComponent<UnityEngine.UI.Text>().text = classScore[i].name;
                points.GetComponent<UnityEngine.UI.Text>().text = classScore[i].points;
                //if (nameScore.GetComponent<UnityEngine.UI.Text>().text == "")
                //{
                //    Debug.Log("44444");
                //    //nameScore.GetComponent<UnityEngine.UI.Text>().text = namePlayer;
                //    nameScore.GetComponent<UnityEngine.UI.Text>().text = bdScore.name;
                //    points.GetComponent<UnityEngine.UI.Text>().text = bdScore.points;
                //    Debug.Log("bdscore3" + bdScore.name);
                //    Debug.Log("bdscore3" + bdScore.points);
                //    //points.GetComponent<UnityEngine.UI.Text>().text = VictoryManager.score.ToString();
                //}
            }
            catch { }
        }
        Debug.Log("delay antes");
        done = true;
        //StartCoroutine(delay());
        Debug.Log("delay depsues");
    }
    void ReadJson()
    {
        path = Application.dataPath + "/ScoreRecords.json";
        using (StreamReader r = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
        {            
            jsonstring = r.ReadToEnd();
            
            BD_Score x = JsonUtility.FromJson<BD_Score>(jsonstring);
            classScore.Add(x);
        }
    }
    void WriteJson()
    {
        foreach(BD_Score b in classScore)
        {            
            using (StreamWriter w = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                string newGamer = JsonUtility.ToJson(b);
                w.WriteLine(newGamer);
            }                        
        }
    }  

    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("delay");
        SceneManager.LoadScene("MenuScene");
    }    
}
