using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    

    




    void Start ()
        {
            GameObject gameControllerObject = GameObject.FindWithTag("GameController");
            if (gameControllerObject != null)
            {
               gameController = gameControllerObject.GetComponent<GameController>();
            }
            if (gameController == null)
            {
                Debug.Log("Cannot find 'GameController' script");
            }

            
            
        }

    //Very important to note that in the Challenge 3 version,
    //under current conditions all gameobjects with this script
    //that collide with another collider component will destroy
    //both gameobjects so as long as their tags are not both hazard tags
    //such as "Boundary" or "Enemy".//

        
        void OnTriggerEnter(Collider other)
		{

            //This if statement is solely used for making sure that the
            //asteroids and enemy ships won't destroy eachother if they
            //were to collide with eachother.
            
		    if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "PickUp")
		    {
			    return;
            }

            //This will currently only happen if any gameobject other than
            //those tagged ""Boundary" or "Enemy" collide with the another
            //gameobject that is tagged "Boundary" or "Enemy". The is used
            //cause the asteroid explosion effect.
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                {
                    Debug.Log("GameObject was Destroyed.");
                }

                if (other.tag == "PlayerBolt" || other.tag == "Torpedo")
                {
                    gameController.AddScore(scoreValue);
                    {
                        Debug.Log("Points Added.");
                    }
                }

            }

            //If the player gameobject collides with the another collider
            //with this script attached it will be destroyed.
            if (other.tag == "Player")
		    {
                {
                    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                    //Destroy(other.gameObject);
                    GameController.health -= 1;
                }
            }

                //Player destroys hazards and enemies to score points//
                //Destroys any gameobject that enters the collider that
                //this script is attached to.
                //Destroy(other.gameObject);
		        //Destroy(gameObject);
		}
}