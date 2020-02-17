using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider healthBar;
    public static int currentHealth;
    
    
    private void Awake()
    {
        healthBar = GetComponent<Slider>();
        currentHealth = 100;
    }
    public int getCurrentHealth()
    {
        return currentHealth;
    }
    /*public void setCurrenthealth(int health)
    {
        this.currentHealth = health;
    }*/
    public void ReduceHealth(string tag)
    {
        Debug.Log("esta disparando el tag" + tag);
        if (tag == "wShot")
        {
            //GetComponent("Player").transform
            //yield return new WaitForSeconds(2f);
            
            
             
        }
        if (tag == "w2Shot")
        {
            currentHealth -= 5;
        }
        if (tag == "cShot")
        {
            currentHealth -= 20;
        }
        
        healthBar.value = currentHealth;
    }    
    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
    }

}
