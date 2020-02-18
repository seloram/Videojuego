using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushPlayer : MonoBehaviour
{
    public float pushPower = 2.0f;
    private RollManager ball;
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
        
        //float force = 3;
        //Debug.Log("colision"+collision.gameObject.tag);
        //// If the object we hit is the enemy
        //if (collision.gameObject.tag == "Player")
        //{
        //    // Calculate Angle Between the collision point and the player
        //    Vector3 dir = collision.contacts[0].point - transform.position;
        ////    // We then get the opposite (-Vector3) and normalize it
        ////    dir = -dir.normalized;
        ////    // And finally we add force in the direction of dir and multiply it by force. 
        ////    // This will push back the player
        ////    GetComponent<Rigidbody>().AddForce(dir * force);
        ////}
        //// how much the character should be knocked back
        //Debug.Log("colision" + collision.collider.name);
        //var magnitude = 12;
        //// calculate force vector
        //var force = transform.position - collision.transform.position;
        //// normalize force vector to get direction only and trim magnitude
        //force.Normalize();
        //gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        ////Debug.Log("bodydwdwdw: " + collision.collider.name);
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
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("colision----->" + other.name);
        Debug.Log("tag----->" + other.tag);
        if (other.tag.CompareTo("Player")==0)
        {
            Debug.Log("acerte");
            var magnitude = 250;
            // calculate force vector
            var force = transform.position + other.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            GameObject insecto = GameObject.FindGameObjectWithTag("Player");
            insecto.GetComponent<Rigidbody>().AddForce(force * magnitude);
            insecto.GetComponent<Rigidbody>().AddForce(Vector3.up * 8, ForceMode.Impulse);
            GameObject clip = GameObject.FindGameObjectWithTag("soundJump");
            clip.GetComponent<AudioSource>().Play();
        }       
    }
    // Start is called before the first frame update
}
