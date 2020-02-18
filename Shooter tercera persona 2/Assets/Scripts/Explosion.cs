using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public Animator warriorAnimator;
    public float smoothTime = 3.0f;
    public Vector3 smoothVelocity = Vector3.zero;
    public bool encontrado=false;
    public DestroyPlayer d;
    private void Start()
    {
        d = GameObject.Find("Scripts").GetComponent<DestroyPlayer>();
        warriorAnimator = GetComponent<Animator>();
    }
    public IEnumerator gameover()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        GameObject clip = GameObject.FindGameObjectWithTag("soundExplosion");
        clip.GetComponent<AudioSource>().Play();
        Instantiate(explosion, transform.position, transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if ((this.gameObject.CompareTag("warrior") || this.gameObject.CompareTag("warrior 2") )&&
                    (!other.CompareTag("colliderWarrior2") && !other.CompareTag("colliderWarrior")))
        {
            //if (other.CompareTag("Player"))
            //{
      
            //    //d.Explosion(other.transform.gameObject, explosion);
            //}
            //GameObject clip = GameObject.FindGameObjectWithTag("soundExplosion");
            //clip.GetComponent<AudioSource>().Play();
            //Instantiate(explosion, other.transform.position, other.transform.rotation);
            //Animator animator = GetComponent<Animator>();
            //animator.Play("PA_WarriorDeath_Clip");
            //StartCoroutine(gameover());
        }

        if (other.CompareTag("Fire"))
        {
            GameObject clip = GameObject.FindGameObjectWithTag("soundExplosion");
            clip.GetComponent<AudioSource>().Play();
            Instantiate(explosion, transform.position, transform.rotation);
            Animator animator = GetComponent<Animator>();
            animator.Play("PA_WarriorDeath_Clip");
        }
        //}
    }
    private void Update()
    {

    }
}
