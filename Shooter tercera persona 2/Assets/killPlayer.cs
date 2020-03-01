using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject fragPlayer;
    public RollManager rollManager;
    public GameObject hitc;
    public GameObject player;
    public GameObject hit;
    public GameObject hitb;
    public GameObject fire;
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
                GameObject death = GameObject.Instantiate(fire, other.transform.position, this.transform.rotation) as GameObject;
            }
            else
            {
                GameObject clip = GameObject.FindGameObjectWithTag("soundLaserWall");
                clip.GetComponent<AudioSource>().Play();
                Vector3 a = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1.7f);
                GameObject go = GameObject.Instantiate(hitb, a, this.transform.rotation) as GameObject;
                GameObject.Destroy(go, 0.5f);
            }
        }
        if (other.CompareTag("pilar"))
        {
            //Vector3 b = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            //GameObject go2 = GameObject.Instantiate(hitc, b, this.transform.rotation) as GameObject;
            //GameObject.Destroy(go2, 0.5f);
            Destroy(this.gameObject);
            GameObject clip = GameObject.FindGameObjectWithTag("soundLaserWall");
            clip.GetComponent<AudioSource>().Play();
            Vector3 a = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+1.7f);
            GameObject go = GameObject.Instantiate(hit, a, this.transform.rotation) as GameObject;
            GameObject.Destroy(go,0.5f);
           
        }
    }
}
