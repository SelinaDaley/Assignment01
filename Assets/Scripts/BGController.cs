/* Author: Selina Daley */
/* File: BGController.cs */
/* Creation Date: Oct 05, 2015 */
/* Description: This script controls the background movement and speed */

using UnityEngine;
using System.Collections;

public class BGController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float speed;

	//PRIVATE INSTANCE VARIABLES
    private GameController gameController;

	// Use this for initialization
	void Start () 
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }

		this._Reset ();	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = new Vector2 (0.0f, 0.0f);
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= speed;
        
        if (gameController.gameOver == false)
        {
            // move the gameObject to the currentPosition
            gameObject.GetComponent<Transform>().position = currentPosition;

            // top boundary check - gameObject meets top of camera viewport        
            if (currentPosition.x <= -5)
            {
                this._Reset();
            }
        }

		
	}

	// Resets our gameObject
	private void _Reset() {
		Vector2 resetPosition = new Vector2 (15.5f, 0.0f);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}
}
