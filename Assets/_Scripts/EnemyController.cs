///////////////////////////////////////////////////////////////////////////////
// Files:			EnemyController.cs
//
// Author:			Sangbeom Yi
// Description:		Manage the Action of Enemy
//
// Revision History 11/20/2015 file created
//					
//
// Last Modified by	11/20/2015

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	// Public Instance Value.
	public Transform player;
	public float speed = 3;

	public int attack = 10;
	public GameController gameController;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if( gameController.MyGameState == GameState.Play ) {
			Vector3 playerPos = player.position;
			Vector3 direction = playerPos - transform.position;
			direction = direction.normalized;
			transform.position = transform.position + (direction * speed * Time.deltaTime);
			transform.LookAt(player);
		}
	}

	void OnTriggerEnter ( Collider col ) {
		if(col.transform.tag == "Player"){
			//Attack(col.gameObject);
			Destroy(this.gameObject);
			this.gameController.Life -= attack;
			if( this.gameController.Life < 0 ) {
				this.gameController.Life = 0;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.transform.tag == "Player"){
			//Attack(col.gameObject);
			this.gameController.Life -= attack;
			Destroy(this.gameObject);
			if( this.gameController.Life < 0 ) {
				this.gameController.Life = 0;
			}
		}
	}
	/*
	public void Attack ( GameObject hit ){
		hit.gameObject.SendMessage("Damage", attack);
	}
	*/
}
