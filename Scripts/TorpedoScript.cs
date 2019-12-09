using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour
{
    public float torpedoRate;
    public GameObject torpedo;
    public Transform torpedoSpawn;
    private float nextFire;
    public AudioSource musicSource2;
    public AudioClip musicClipTwo;
    

    void Update()
    {
        if (Input.GetKey(KeyCode.C) && Time.time > nextFire)
        {
            Debug.Log("Torpedo Fired");
            musicSource2.clip = musicClipTwo;
            musicSource2.Play();
            nextFire = Time.time + torpedoRate;
            Instantiate(torpedo, torpedoSpawn.position, torpedoSpawn.rotation);
        }
    }
}
