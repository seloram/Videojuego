﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStars : MonoBehaviour
{
    public GameObject stars;
    private Vector3 randomVector;

    public void Update()
    {
        randomVector = new Vector3(Random.Range(-30, 30), Random.Range(-15, -3), 35);

        Instantiate(stars, randomVector, transform.rotation);
    }
}
