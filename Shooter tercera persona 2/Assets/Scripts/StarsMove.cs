using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMove : MonoBehaviour
{
    private float zMovement;
    private float timeDestroy = 0.0f;

    private void Start()
    {
        zMovement = Random.Range(-5, -20) * Time.deltaTime;
    }
    public void Update()
    {
        gameObject.transform.Translate(0, 0, zMovement);
        timeDestroy += Time.deltaTime;
        if (timeDestroy > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
