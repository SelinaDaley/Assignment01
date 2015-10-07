/* Author: Selina Daley */
/* File: Down.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script moves the Gameobject it is attached to up or down on the screen */

using UnityEngine;
using System.Collections;

public class Down : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float speed;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.up * speed; //Moves up or down
	}
	
	// Update is called once per frame
	void Update () {

		if(this.transform.position.y <= -1.45f)
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
