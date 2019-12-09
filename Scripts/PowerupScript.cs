using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    //public AudioSource musicSource;
    //public AudioClip musicClipOne;
    public GameObject pickupEffect;
    private GameController gameController;
    public TorpedoScript player;

    void Start()
    {
        //player.GetComponent<TorpedoScript>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1000, 0) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player.enabled = !player.enabled;
            //musicSource.clip = musicClipOne;
            //musicSource.Play();
            Pickup();
            Torpedo();
            GameController.health += 1;
        }
    }

    void Pickup()
    {
        //player.GetComponent<TorpedoScript>().enabled = true;
        Debug.Log("Power up picked up!");
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }

    void Torpedo()
    {
        
    }
}
