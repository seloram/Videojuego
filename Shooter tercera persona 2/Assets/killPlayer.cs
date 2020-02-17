using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject fragPlayer;
    public RollManager rollManager;
    public GameObject player;
    public DestroyPlayer d;

    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        d = GameObject.Find("Scripts").GetComponent<DestroyPlayer>();
        rollManager = GameObject.Find("HealthSlider").GetComponent<RollManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("esta disparando " + this.tag);
        if (other.CompareTag("colliderWarrior2")||other.CompareTag("colliderWarrior"))
        {
            d.Explosion(other.transform.parent.gameObject, fragPlayer);
        }
        if (other.CompareTag("Player"))
        {
            rollManager.ReduceHealth(this.tag);
            Destroy(this.gameObject);
            if (rollManager.getCurrentHealth() <= 0)
            {
                d.Explosion(player, fragPlayer);
            }
        }
        if (other.CompareTag("pilar"))
        {
            Destroy(this.gameObject);
            GameObject clip = GameObject.FindGameObjectWithTag("soundLaserWall");
            clip.GetComponent<AudioSource>().Play();
        }
    }
}
