using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCountDown : MonoBehaviour
{
    public AudioClip audio;
    private int count;
    public AudioClip audioEndGame;
    public AudioClip audioVictory;
    private GameObject animCountDown;
    private GameObject textCount;
    public AudioSource clip;
    private bool finished;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            if (int.Parse(GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text) == 10)
            {
                clip.Stop();
                clip.clip = audio;
                clip.Play();
            }
            count = int.Parse(GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text);
            if (count <= 5 && count >= 1)
            {
                animCountDown = GameObject.FindGameObjectWithTag("animCountDown");
                animCountDown.transform.localScale = new Vector3(1, 1, 1);
                textCount = GameObject.FindGameObjectWithTag("countAnim");
                Animator a = textCount.GetComponent<Animator>();
                a.Play("CountDownAnimation");
                StartCoroutine(nextNumber(a));
            }

            string endgame = GameObject.FindGameObjectWithTag("endGame").GetComponent<UnityEngine.UI.Text>().text;
            if (endgame == "Game Over!!!")
            {
                clip.loop = false;
                clip.Stop();
                clip.clip = audioEndGame;
                clip.Play();
                animCountDown.transform.localScale = new Vector3(0, 0, 0);
                textCount.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                if (endgame == "You Win!!!")
                {
                    clip.loop = false;
                    clip.Stop();
                    clip.clip = audioVictory;
                    clip.Play();
                    finished = true;
                    animCountDown.transform.localScale = new Vector3(0, 0, 0);
                    textCount.transform.localScale = new Vector3(0, 0, 0);
                }
            }
        }
             
    }
    IEnumerator nextNumber(Animator a)
    {        
        yield return new WaitForSeconds(a.GetComponents<Animation>().Length+0.5f);
        GameObject animCount = GameObject.FindGameObjectWithTag("countAnim");
        animCount.GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text;        
    }
}
