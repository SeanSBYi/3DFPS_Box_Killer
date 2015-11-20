///////////////////////////////////////////////////////////////////////////////
// Files:			EnemyGenerator.cs
//
// Author:			Sangbeom Yi
// Description:		Manage the Generating of Enemy
//
// Revision History 11/20/2015 file created
//					
//
// Last Modified by	11/20/2015

using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	// Public Instance Value.
	public Transform ground ;
	public float interval = 5.0f;
	public int count = 3;
	public GameObject enemy;
	public GameController gameController;

	// Instance Instance Value.
	private float timer;

	// Use this for initialization
	void Start () {
		//Spawn();
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if(timer >= interval){
			if( gameController.MyGameState == GameState.Play ) {
				Spawn();
			}
			timer = 0.0f;
		}
	}

	// Spawn the Enemy
	void Spawn () {
		for (int i = 0; i < count; i++) {
			float x = Random.Range (5.0f, 25.0f);
			float z = Random.Range (5.0f, 25.0f);
			Vector3 pos = new Vector3 (x, 2, z) + ground.position;
			GameObject.Instantiate (enemy, pos, Quaternion.identity);
		}
	}
}