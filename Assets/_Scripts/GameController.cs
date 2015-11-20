using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState{
	None,
	Play,
	Pause,
	End
}

public class GameController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public Text scoreLabel;
	public Text lifeLabel;
	public GameState GS;

	// PRIVATE INSTANCE VARIABLES
	private int _scoreValue = 0;
	private int _liveValue = 100;

	// PUBLIC PROPERTIES
	public int Score {
		get {
			return _scoreValue;
		}
		set {
			_scoreValue = value;
			this._updateHUD();
		}
	}

	public int Life {
		get {
			return _liveValue;
		}
		set {
			_liveValue = value;
			this._updateHUD();
		}
	}

	// Use this for initialization
	void Start () {
		//Set Cursor to not be visible
		Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;

		this._updateHUD ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			Cursor.lockState = CursorLockMode.None;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;	
	}

	// PRIVATE METHODS
	private void _updateHUD() {
		this.scoreLabel.text = "Score: " + this._scoreValue;
		this.lifeLabel.text = "Life: " + this._liveValue;
	}

	public GameState MyGameState {
		get {
			return this.GS;
		}
		set {
			GS = value;
		}
	}
}
