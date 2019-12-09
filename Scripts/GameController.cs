using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text winText;
    private int score;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool win;
    private bool restart;

    public GameObject life1, life2, life3, life4;
    public static int health;
    public BGScroller scroll;
    public GameObject starfield1;
    public GameObject starfield2;
    public AudioSource winMusic;
    public AudioClip winAudio;
    public AudioSource gameoverMusic;
    public AudioClip gameoverAudio;
    public AudioSource backgroundMusic;
    public AudioClip backgroundAudio;
    public GameObject player;

    //public GameObject playerCollider;

    void Start()
    {
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        restart = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        health = 3;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        life4.gameObject.SetActive(false);
        gameOver = false;
        backgroundMusic.clip = backgroundAudio;
        backgroundMusic.Play();
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.Q))
            {
                SceneManager.LoadScene("SampleScene"); // or whatever the name of your scene is
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        //IN THEORY THIS MIGHT WORK FOR SHIELDS AS WELL//
        if (health > 4)
            health = 4;

        switch (health)
        {
            case 4:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                break;
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(false);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                break;
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                player.SetActive(false);
                gameOver = true;
                GameOver();
                break;
            

        }

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                gameoverMusic.clip = gameoverAudio;
                gameoverMusic.Play();
                restartText.text = "Press 'Q' for Restart";
                restart = true;
                break;
            }
            if (win)
            {
                winMusic.clip = winAudio;
                winMusic.Play();
                restartText.text = "Press 'Q' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            //if (playerCollider.GetComponent<MeshCollider>().enabled == true)
            //{
                //playerCollider.GetComponent<MeshCollider>().enabled = false;
            //}
            //Destroy(GameObject.Find("Enemy"));
            winText.text = "You Win! Game created by Brian Mikolajczyk";
            win = true;
            restart = true;
            scroll.scrollSpeed = -18;
            starfield2.SetActive(true);
            starfield1.SetActive(false);
            backgroundMusic.Stop();
        }
    }

    public void GameOver ()
    {
        backgroundMusic.Stop();
        gameOverText.text = "Game Over!";
        gameOver = true;

        Debug.Log("Game Over Audio Playing");
    }
}
