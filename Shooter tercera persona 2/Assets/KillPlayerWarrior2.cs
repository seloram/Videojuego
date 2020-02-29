using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerWarrior2 : MonoBehaviour
{
    public GameObject fragPlayer;
    public RollManager rollManager;
    public GameObject hit;
    public GameObject hitw1;
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
            else
            {
                Vector3 a = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1.7f);
                GameObject go = GameObject.Instantiate(hit, a, this.transform.rotation) as GameObject;
                GameObject.Destroy(go, 0.5f);
               
                if (this.tag == "wShot")
                {
                    other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                }
            }
        }
        if (other.CompareTag("pilar"))
        {
            Vector3 a = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1.7f);
            GameObject go = GameObject.Instantiate(hit, a, this.transform.rotation) as GameObject;
            GameObject.Destroy(go, 0.5f);
            Destroy(this.gameObject);
            GameObject clip = GameObject.FindGameObjectWithTag("soundLaserWall");
            clip.GetComponent<AudioSource>().Play();
        }
    }  
}
