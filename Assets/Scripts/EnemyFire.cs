/* Author: Selina Daley */
/* File: EnemyFire.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script is used to make the GameObject that it is attached to shoot bullets */

using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public Transform shotSpawn;
	public GameObject enemyShot1;
	public float fireRate;

	//PRIVATE INSTANCE VARIABLES
	private float _nextFire;

	// Update is called once per frame
	void Update () {
		this._CheckFire ();
	}

	private void _CheckFire()
	{
		if(Time.time > _nextFire)
		{
			_nextFire = Time.time + fireRate;
			Instantiate (enemyShot1, shotSpawn.position, shotSpawn.rotation);
		}		
	}
}