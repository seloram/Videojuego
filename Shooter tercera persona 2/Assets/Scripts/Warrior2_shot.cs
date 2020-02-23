using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior2_shot : MonoBehaviour
{
    public Transform m_cannonRot;
    public Transform m_muzzle;
    public GameObject m_shotPrefab;
    public Texture2D m_guiTexture;
    public float rotateSpeed = 3.0f;
    public GameObject target;
    public float fireRate = 0.5f;
    private float lastShoot;
    // Use this for initialization
    void Start()
    {
        lastShoot = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GetDistance(target.transform) <= 10.0f)
            {      
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

    float GetDistance(Transform objetivo)
    {
        Vector3 director = this.transform.position - objetivo.position;

        return director.magnitude;
    }
}
