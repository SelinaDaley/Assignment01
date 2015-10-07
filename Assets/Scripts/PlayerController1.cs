/* Author: Selina Daley */
/* File: OceanController.cs */
/* Creation Date: Oct 05, 2015 */
/* Description: This script controls the player gameObject's movement */

using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {
	
	//PUBLIC INSTANCE VARIABLES
	public Vector2 move = new Vector2(0, 0);
	public Boundary boundary;
	public GameObject shot1;
	public GameObject bomb;
	public Transform shotSpawn;	
	public float speed;
	public float fireRate;
	private float nextFire;
	
	// Update is called once per frame
	void Update () {
		this._CheckFire ();
	}
	
	private void _CheckFire()
	{
		if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot1, shotSpawn.position, shotSpawn.rotation);
		}
		if(Input.GetKey(KeyCode.B) && Time.time > nextFire + 0.5f)
		{
			nextFire = Time.time + fireRate;
			Instantiate (bomb, shotSpawn.position, shotSpawn.rotation);
		}		
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3 (
			
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
			0.0f
		);		
	}
}
