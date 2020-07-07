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
    public GameObject textInput;
    public GameObject placeholder;
    string namePlayer;
    bool done = true;
    public GameObject inputNamePlayer;
    // Start is called before the first frame update
    void Start()
    {       
        classScore = new List<BD_Score>();
        bdScore = new BD_Score();
        ReadJson();

        scoreList.transform.localScale = new Vector3(0, 0, 0);
        inputNamePlayer.transform.localScale = new Vector3(0, 0, 0);
        placeholder.transform.localScale = new Vector3(0, 0, 0);
        textInput.transform.localScale = new Vector3(0, 0, 0);
        
        //inputNamePlayer = GameObject.FindGameObjectWithTag("inputNamePlayer");
        Debug.Log("points 10 " + classScore[classScore.Count-1].points);
        if (classScore.Count < 9)
        {
            Debug.Log("points 102 " + classScore[classScore.Count-1].points);
            if (VictoryManager.score > classScore[classScore.Count-1].points)
            {                
                done = false;
            }
        }
        Debug.Log("points 104 " + classScore[classScore.Count-1].points);
        if (!done)
        {
            Debug.Log("done " + done.ToString());
            inputNamePlayer.transform.localScale = new Vector3(1, 1, 1);
            placeholder.transform.localScale = new Vector3(1, 1, 1);
            textInput.transform.localScale = new Vector3(1, 1, 1);
            inputNamePlayer.GetComponent<Animator>().SetBool("Open", true);
        }
        else
        {
            Debug.Log("lo ha cargado");
            namesList();
        }            

        //scoresFile = PlayerPrefs.GetString("scores");
        //Debug.Log("scoresfileinicial" + scoresFile);
        //bdScore = JsonUtility.FromJson<BD_Score>(scoresFile);
    }

    // Update is called once per frame
    void Update()
    {
        //if (done)
        //{
        //    //Debug.Log("tamaño" + inputNamePlayer.transform.localScale.ToString());
        //    //inputNamePlayer.transform.localScale = new Vector3(0, 0, 0);
        //    //Debug.Log("tamaño" + inputNamePlayer.transform.localScale.ToString());
        //    classScore.Sort((a, b) => a.points.CompareTo(b.points));
        //    WriteJson();
        //    inputNamePlayer.GetComponent<Animator>().SetBool("Close", true);
        //    inputNamePlayer.GetComponent<Animator>().SetBool("Open", false);
        //    scoreList.GetComponent<Animator>().SetBool("Open", true);
        //    StartCoroutine(delay());
        //}
    }

    public void namesList()
    {        
        scoreList.transform.localScale = new Vector3(1, 1, 1);
        if (!done)
        {
            namePlayer = GameObject.FindGameObjectWithTag("namePlayer").GetComponent<UnityEngine.UI.Text>().text;
            bdScore.name = namePlayer;
            bdScore.points = VictoryManager.score;
            classScore.Add(bdScore);
            classScore.Sort((a, b) => b.points.CompareTo(a.points));
        }

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
                nameScore.GetComponent<UnityEngine.UI.Text>().text = classScore[i-1].name;
                points.GetComponent<UnityEngine.UI.Text>().text = classScore[i-1].points.ToString();
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
            name = "name_";
            score = "score_";
        }
        ScoreDone();
        StartCoroutine(Paging());
        StartCoroutine(delay());
    }

    void ReadJson()
    {
        path = Application.dataPath + "/ScoreRecords.json";
        using (StreamReader r = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
        {            
            jsonstring = r.ReadLine();
            if (jsonstring.Length > 0)
            {
                while (jsonstring != null)
                {
                    BD_Score x = JsonUtility.FromJson<BD_Score>(jsonstring);
                    classScore.Add(x);
                    jsonstring = r.ReadLine();
                }
            }

        }
    }

    void WriteJson()
    {        
        using (StreamWriter w = new StreamWriter(new FileStream(path, FileMode.Create)))
        {
            foreach (BD_Score b in classScore)
            {
                string newGamer = JsonUtility.ToJson(b);
                w.WriteLine(newGamer);
            }
        }
    }  
    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(8);
        Debug.Log("delay");
        SceneManager.LoadScene("MenuScene");
    }   
    
    IEnumerator Paging()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("paging");
        GameObject nameScore = null;
        GameObject points = null;
        string name = "name_";
        string score = "score_";
        for (int i = 1; i <= 5; i++)
        {
            Debug.Log("paging2");
            name += i;
            score += i;
            try
            {
                Debug.Log("paging3");
                Debug.Log("paging3 name " + name);
                Debug.Log("paging3 name " + score);
                Debug.Log("nueva pagina2" + classScore[i+4].name);
                nameScore = GameObject.FindGameObjectWithTag(name);
                Debug.Log("paging3 nameScore " + nameScore);
                points = GameObject.FindGameObjectWithTag(score);
                Debug.Log("nueva pagina" + classScore[i+4].name);
                if (classScore[i+4]!=null)
                {
                    Debug.Log("paging4");
                    nameScore.GetComponent<UnityEngine.UI.Text>().text = classScore[i+4].name;
                    Debug.Log("nueva pagina" + classScore[i+4].name);
                    points.GetComponent<UnityEngine.UI.Text>().text = classScore[i+4].points.ToString();
                }
            }
            catch { }
            name = "name_";
            score = "score_";
        }
    }

    void ScoreDone()
    {
        classScore.Sort((a, b) => b.points.CompareTo(a.points));
        if (!done)
        {
            WriteJson();
        }
            
        inputNamePlayer.GetComponent<Animator>().SetBool("Close", true);
        inputNamePlayer.GetComponent<Animator>().SetBool("Open", false);
        scoreList.GetComponent<Animator>().SetBool("Open", true);
        //StartCoroutine(delay());
    }
}
