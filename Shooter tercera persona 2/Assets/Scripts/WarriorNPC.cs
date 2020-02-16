using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorNPC : MonoBehaviour
{
    Animator m_Animator;
    public GameObject nextPlayerToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
