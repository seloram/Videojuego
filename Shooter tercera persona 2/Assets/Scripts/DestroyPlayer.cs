using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject explosion;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public DestroyPlayer()
    {

    }
    public void Explosion(GameObject other, GameObject explosion)
    {        
        if (other.CompareTag("Player"))
        {
            RollManager.currentHealth = 0;
        }
        GameObject clip = GameObject.FindGameObjectWithTag("soundExplosion");
        clip.GetComponent<AudioSource>().Play();
        Instantiate(explosion, other.transform.position, other.transform.rotation);
        Destroy(other);
    }
}
