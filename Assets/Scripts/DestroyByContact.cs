/* Author: Selina Daley */
/* File: DestroyByContact.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script detects when the GameObject it is attached to collides with the player */

using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public GameObject explosion;
	public GameObject enemyDeath;
	public GameObject playerDeath;
	public GameObject enemyExplosion;
	public int scoreValue;

	//PRIVATE INSTANCE VARIABLES
	private int _decreaseLife = 1;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' Script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag != "Boundary") 
		{
			if(other.tag == "Player" && gameController.life > 1) //Check if this object collided with the player and if the player has more than one life left
			{
				Instantiate (playerDeath, other.transform.position, other.transform.rotation);
				Instantiate (explosion, transform.position, transform.rotation);
				Instantiate (enemyExplosion, transform.position, transform.rotation);
				Instantiate (enemyDeath, transform.position, transform.rotation);
				gameController.DecreaseLife(_decreaseLife);
				Destroy(gameObject);
			}
			else if(other.tag == "Player") //If this object collided with the player and the player has no lives life end the game
			{			
				Instantiate (playerDeath, other.transform.position, other.transform.rotation);
				Instantiate (enemyDeath, transform.position, transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);
				gameController.DecreaseLife(_decreaseLife);
				gameController.GameOver();
			}
            else if(other.tag == "Life") //If this object collided with the life or do nothing
            {
				//Do nothing
            }
			else
			{
				if(this.gameObject.tag != other.gameObject.tag) //If this collided with the players shot or bomb add to score
				{
					gameController.AddScore(scoreValue);
					Instantiate (explosion, transform.position, transform.rotation);
					Instantiate (enemyDeath, transform.position, transform.rotation);
					Destroy (other.gameObject);
					Destroy (gameObject);
				}
			}
		}
	}
}