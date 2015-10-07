/* Author: Selina Daley */
/* File: Mover.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script moves the Gameobject it is attached to left or right on the screen */

using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float speed;

	void Start() {
		GetComponent<Rigidbody> ().velocity = transform.right * speed; //Moves the gameobject horizontally
	}

}
