﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VictoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    Text victoryText;
    GameTimer gametimer;
    RollManager rollmanager;
    static public int score;
    private void Awake()
    {
        victoryText = GetComponent<Text>();
        victoryText.text="";
    }
    void Start()
    {
        gametimer = GameObject.Find("GameTimeLeft").GetComponent<GameTimer>();        
    }

    // Update is called once per frame
    public IEnumerator TheEnd()
    {
        score = calculateScore();
        Debug.Log("score--->2" + score);
        yield return new WaitForSeconds(2f);
        GameObject gamemanager = GameObject.Find("GameTimeLeft");
        Destroy(gamemanager);

        
        Time.timeScale = (isActiveAndEnabled) ? 0 : 1f;     
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player")!=null){
            if (GameObject.FindGameObjectWithTag("Player").transform.position.y < 0)
            {
                victoryText.text = "Game Over!!!";
                if (Input.GetKeyDown("space"))
                {
                    SceneManager.LoadScene(2);
                    Time.timeScale = 1f;
                }
                StartCoroutine(TheEnd());
            }            
        }

        if (CoinsManager.currentCoinCount == 0)
        {
            victoryText.text = "You Win!!!";
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(2);
                Time.timeScale = 1f;
            }
            StartCoroutine(TheEnd());

        }

        if (RollManager.currentHealth == 0 || GameObject.FindGameObjectWithTag("Player")==null)
        {
            victoryText.text = "Game Over!!!";
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(2);
                Time.timeScale = 1f;
            }
            StartCoroutine(TheEnd());
        }

        if (gametimer.getCountDown()<=0)
        {
            victoryText.text = "Game Over!!!";            
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(2);
                Time.timeScale = 1f;
            }
            StartCoroutine(TheEnd());
        }
    }
    private int calculateScore()
    {
        int coins = CoinsManager.currentCoinCount;
        int health = RollManager.currentHealth;
        int time = (int)gametimer.getCountDown();
        Debug.Log("time" + time);
        score = (5 - coins) * health - time;
        Debug.Log("score--->" + score);
        return score;
    }

}
