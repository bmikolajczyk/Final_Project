using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    private Rigidbody rb;
    public float fireRate;
    private float nextFire;
    public AudioSource musicSource1;
    public AudioClip musicClipOne;
    //public AudioSource musicSource2;
    //public AudioClip musicClipTwo;
    //public float torpedoRate;
    //public GameObject torpedo;
    //public Transform torpedoSpawn;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            musicSource1.clip = musicClipOne;
            musicSource1.Play();
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        //if (Input.GetKey(KeyCode.C) && Time.time > nextFire)
        //{
            //musicSource2.clip = musicClipTwo;
            //musicSource2.Play();
            //nextFire = Time.time + torpedoRate;
            //Instantiate(torpedo, torpedoSpawn.position, torpedoSpawn.rotation);
        //}
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
