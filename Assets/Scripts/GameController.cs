/* Author: Selina Daley */
/* File: GameController.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script controls the text, enemy spawns, life spawns, score, and restart */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
    public GameObject lifeOrb;
	public AudioSource gameMusic;
	public AudioSource gameOverMusic;
	
	public Vector3 spawnValues;
	public int hazardCount;
    public int othersCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text lifeText;
	public Text timeText;
	public Text restartText;
	public Text gameOverText;

	public int life;
	public bool gameOver;

	//PRIVATE INSTANCE VARIABLES
	private bool _restart;
	private int _score;
	private int _time;

	void Start() {
		timeText.text = "Time: " + _time;
		restartText.text = "";
		gameOverText.text = "";
		gameOver = false;
		_restart = false;
		_score = 0;
		_time = 0;

		UpdateScore ();
		UpdateLife ();
	    StartCoroutine(SpawnWaves1());
		StartCoroutine(SpawnWaves2());
		StartCoroutine(SpawnWaves3());
		StartCoroutine(SpawnWaves4());
        StartCoroutine(SpawnObjects());
	}

	void Update() {

		_time = Mathf.RoundToInt (Time.timeSinceLevelLoad);

		if (gameOver == false) {
			timeText.text = "Time: " + _time;
		}

		if (_restart) {
			if(Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves1() {
		yield return new WaitForSeconds(startWait);
		while(true){
			for (int i = 0; i < hazardCount; i++) 
			{
				if(gameOver) {	break;	} 

				timeText.text = "Time: " + _time;
				Vector3 spawnPosition = new Vector3 ( spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y + 1), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy1, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver) 
            {
				restartText.text = "Press 'R' to restart the game";
				_restart = true;
				break;
			}           
		}
	}

	IEnumerator SpawnWaves2()
	{
		yield return new WaitForSeconds(startWait + 0.25f);
		while (true)
		{
			for (int i = 0; i < hazardCount - 3; i++)
			{
				if(gameOver) {	break;	} 

				Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y + 1, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(enemy2, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait + 0.25f);
			}
			yield return new WaitForSeconds(waveWait + 1.35f);
		}
	}

	IEnumerator SpawnWaves3()
	{
		yield return new WaitForSeconds(startWait + 1);
		while (true)
		{
			for (int i = 0; i < hazardCount - 8; i++)
			{
				if(gameOver) {	break;	} 
				
				Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y + 1), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(enemy3, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait + 3f);
			}
			yield return new WaitForSeconds(waveWait + 2f);
		}
	}

	IEnumerator SpawnWaves4()
	{
		yield return new WaitForSeconds(startWait + 3);
		while (true)
		{
			for (int i = 0; i < hazardCount - 8; i++)
			{
				if(gameOver) {	break;	} 
				
				Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y + 1), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(enemy4, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait + 3f);
			}
			yield return new WaitForSeconds(waveWait + 2f);
		}
	}

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWait + 17);
        while (true)
        {
            for (int i = 0; i < othersCount; i++)
            {
				if(gameOver) {	break;	} 

                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y + 1), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(lifeOrb, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait + 15);
        }
    }

	public void AddScore(int newScoreValue) {
		_score += newScoreValue;
		UpdateScore ();
	}

	public void UpdateScore() 
	{
		scoreText.text = "Score: " + _score;
	}

	public void DecreaseLife(int decLife)
	{
		life -= decLife;
		UpdateLife ();
	}
    public void IncreaseLife(int IncLife)
    {
        life += IncLife;
        UpdateLife();
    }
	public void UpdateLife()
	{
		lifeText.text = "Lives: " + life;

		if(life == 0)
		{
			GameOver();
		}
	}
	public void GameOver() 
    {
		gameMusic.Stop();
		gameOverMusic.Play();
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}