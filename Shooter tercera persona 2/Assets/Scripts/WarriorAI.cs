using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAI : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isDead = false;

    public float speed = 5f;
    public float directionChangeInterval = 1f;
    public float maxHeadingChange = 30f;

    Animator warriorAnimator;

    CharacterController controller;
    float heading;
    Vector3 targetRotation;
    void Start()
    {
        warriorAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
