/* Author: Selina Daley */
/* File: DestroyByContact2.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script detects when the Bomb enemy collides with the player or players bomb/shot */

using UnityEngine;
using System.Collections;

public class DestroyByContact2 : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public GameObject explosion;
	public GameObject playerDeath;

	//PRIVATE INSTANCE VARIABLES
	private int _decreaseLife = 1;
	private GameController gameController;

	// Use this for initialization
	void Start () {
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
			if(other.tag == "Player" && gameController.life > 1) 
			{
				Instantiate (playerDeath, other.transform.position, other.transform.rotation);
				Instantiate (explosion, transform.position, transform.rotation);
				gameController.DecreaseLife(_decreaseLife);
				Destroy(gameObject);
			}
			else if(other.tag == "Player")
			{				
				Instantiate (playerDeath, other.transform.position, other.transform.rotation);
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);
				gameController.DecreaseLife(_decreaseLife);
				gameController.GameOver();
			}
		}
	}
}