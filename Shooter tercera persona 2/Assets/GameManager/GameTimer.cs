using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float maxTime = 60f;
    private float countdown = 0f;
    public AudioClip audio;
    public Text timeLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = GetComponent<Text>();        
        countdown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        timeLeft.text =  ((int)countdown).ToString();

    }

    public float getCountDown()
    {
        return countdown;
    }
}
