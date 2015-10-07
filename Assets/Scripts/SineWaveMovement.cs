/* Author: Selina Daley */
/* File: SineWaveMovement.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script moves the Gameobject it is attached to in a sinusoidal motion on the screen */

using UnityEngine;
using System.Collections;

public class SineWaveMovement : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public float speed;
	public float floatStrength = 1; //the range of y positions that are possible.

	//PRIVATE INSTANCE VARIABLES
	private float _xPos;
	private float _yPos;

	void Start()
	{
		this._xPos = this.transform.position.x;
		this._yPos = this.transform.position.y;
	}
	
	void Update()
	{
		_xPos += speed; 
		transform.position = new Vector3(_xPos, _yPos + ((float)Mathf.Sin(Time.time) * floatStrength), transform.position.z);
	}
}
