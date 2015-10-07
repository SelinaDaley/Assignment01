/* Author: Selina Daley */
/* File: ObjectController.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script adds life to the Player's total life count */

using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public AudioSource orbObject;

	//PRIVATE INSTANCE VARIABLES
	private GameController gameController;
	private int _increaseLife = 1;

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
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            if (other.tag == "Player")
            {
				orbObject.Play(); //Play the sound that is attached to this object
				Invoke("_DestroyIt", 0.15f); //Wait 0.15 second then destroy this object
                gameController.IncreaseLife(_increaseLife);
            }
        }
    }	

	private void _DestroyIt()
	{
		Destroy (gameObject);
	}
}