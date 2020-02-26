using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCountDown : MonoBehaviour
{
    public AudioClip audio;
    private int count;
    public AudioClip audioEndGame;
    
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text) == 10)
        {
            AudioSource clip = GetComponent<AudioSource>();
            clip.Stop();       
            clip.clip = audio;        
            clip.Play();           
        }
        count = int.Parse(GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text);
        if (count <= 5&&count>=1)
        {
            GameObject animCountDown = GameObject.FindGameObjectWithTag("animCountDown");
            animCountDown.transform.localScale = new Vector3(1, 1, 1);
            GameObject textCount = GameObject.FindGameObjectWithTag("countAnim");
            Animator a = textCount.GetComponent<Animator>();
            a.Play("CountDownAnimation");
            Debug.Log("aaaa" + a.ToString());            
            StartCoroutine(nextNumber(a));
        }
 
            string endgame = GameObject.FindGameObjectWithTag("endGame").GetComponent<UnityEngine.UI.Text>().text;
            if(endgame== "Game Over!!!")
            {
                AudioSource clip = GetComponent<AudioSource>();
                clip.Stop();
                clip.clip = audioEndGame;
                clip.Play();
            }        
    }
    IEnumerator nextNumber(Animator a)
    {        
        yield return new WaitForSeconds(a.GetComponents<Animation>().Length);
        GameObject animCount = GameObject.FindGameObjectWithTag("countAnim");
        animCount.GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("GameTimeLeft").GetComponent<GameTimer>().timeLeft.text;        
    }
}
