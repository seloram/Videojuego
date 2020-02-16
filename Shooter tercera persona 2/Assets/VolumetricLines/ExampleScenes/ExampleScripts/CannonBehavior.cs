using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public Transform m_cannonRot;
	public Transform m_muzzle;
	public GameObject m_shotPrefab;
	public Texture2D m_guiTexture;
    public float rotateSpeed = 3.0f;
    public GameObject target;
    public float fireRate = 0.5f;
    private float lastShoot;
	// Use this for initialization
	void Start () 
	{
        lastShoot = Time.time;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GetDistance(target.transform) <= 20.0f)
            {

                RotateTowardsTarget();
                if (lastShoot < Time.time)
                {
                    GameObject clip = GameObject.FindGameObjectWithTag("soundLaser");
                    clip.GetComponent<AudioSource>().Play();
                    lastShoot = Time.time + fireRate;
                    GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
                    GameObject.Destroy(go, 3f);
                }
            }
        }
	}
    IEnumerator shoot()
    {
        yield return new WaitForSeconds(100.0f);
    }

    void RotateTowardsTarget()
    {
        /*Direction indica el vector que empieza donde el enemigo
         * y acaba donde el objetivo*/
        Vector3 direction = target.transform.position - this.transform.position;
        /*DirectionToFace indica la rotatción que debo 
         * sufrir para mirar hacia el objetivo*/
        Quaternion directionToFace = Quaternion.LookRotation(direction);
        /*El ángulo de rotación viene dado por s=v*t*/
        float angleToRotate = this.rotateSpeed * Time.deltaTime;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            directionToFace, angleToRotate);
    }
    float GetDistance(Transform objetivo)
    {
        Vector3 director = this.transform.position - objetivo.position;

        return director.magnitude;
    }
}
