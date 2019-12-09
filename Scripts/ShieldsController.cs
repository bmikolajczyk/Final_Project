using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldsController : MonoBehaviour
{
	public GameObject explosion;
	public GameObject enemyExplosion;
	private Rigidbody rb;


	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Destroy(other.gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
			Instantiate(enemyExplosion, transform.position, transform.rotation);
		}
	}
}