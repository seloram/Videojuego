using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerWarrior2 : MonoBehaviour
{
    public GameObject fragPlayer;
    public RollManager rollManager;
    public GameObject player;
    public DestroyPlayer d;
    public Material material;
    public Material originalMaterial;

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
        if (other.CompareTag("Player"))
        {
            rollManager.ReduceHealth(this.tag);
            Destroy(this.gameObject);
            if (rollManager.getCurrentHealth() <= 0)
            {
                d.Explosion(player, fragPlayer);
            }
            if (this.tag == "wShot")
            {
                //GameObject.Find("Player")..GetComponent<Ball>();
                other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                //player.GetComponent<Renderer>().material = material;
                //StartCoroutine(freezePlayer());
                ////freezePlayer(other);
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
