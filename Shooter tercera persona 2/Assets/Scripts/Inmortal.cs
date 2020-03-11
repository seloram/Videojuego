using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmortal : MonoBehaviour
{
    static Inmortal inmortal;
    public static Inmortal GetInmortal()
    {
        return inmortal;
    }
    private void Awake()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        if (inmortal != null && inmortal!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        inmortal = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
