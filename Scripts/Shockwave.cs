using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{

    public GameObject torpedoExplosion;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary" || other.tag == "Player")
        {
            return;
        }

        if (other.tag == "Enemy")
        {
            if (torpedoExplosion != null)
            {
                Instantiate(torpedoExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
