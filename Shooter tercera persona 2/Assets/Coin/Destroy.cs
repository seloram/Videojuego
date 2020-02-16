using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Player")==true)
        {
            Destroy(gameObject);
        }
        Debug.Log("asfe");

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {

        }
    }
}
