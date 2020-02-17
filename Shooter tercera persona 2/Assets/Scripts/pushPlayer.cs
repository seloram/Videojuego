using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushPlayer : MonoBehaviour
{
    public float pushPower = 2.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        Rigidbody body = hit.controller.attachedRigidbody;
        Debug.Log("bodydwdwdw: " + body.name);
        if ((body == null) || (body.isKinematic))
        {
            return;
        }
        Vector3 push = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = push * pushPower;
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        //Rigidbody body = collision.collider.attachedRigidbody;

        //if ((body == null) || (body.isKinematic))
        //{
        //    return;
        //}
        //Vector3 push = new Vector3(collision.moveDirection.x, 0, hit.moveDirection.z);
        //body.velocity = push * pushPower;
        ////Vector3 push = new Vector3(collision.rigidbody..moveDirection.x, 0, hit.moveDirection.z);
        ////body.velocity = push * pushPower;
        //Debug.Log("body: " + body.name);
    }
    // Start is called before the first frame update

}
