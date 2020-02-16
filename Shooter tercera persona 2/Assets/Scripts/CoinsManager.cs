using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string tag = "Coin1";
    public static int currentCoinCount = 0;
    Text coinTextCount;
    public GameObject[] coins;
    void Start()
    {
        coinTextCount = GetComponent<Text>();
        currentCoinCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag(tag);
        currentCoinCount = coins.Length;
        coinTextCount.text = currentCoinCount.ToString();        
    }
}
