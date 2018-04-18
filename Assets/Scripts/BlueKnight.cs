using UnityEngine;
using System.Collections;

public class BlueKnight : MonoBehaviour {

	[HideInInspector]
	public float moveSpeed = 0.7f;
	public float health = 4;
	public float damage = 6;
	public GameObject coinPrefab;
	private GameObject coin;
	private int score = 100;
	private bool inCreek = false;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, 0);
	}

	void stopForAnimation(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
	}
	
	void beginWalkingAgain() {
		GetComponent<Animator> ().SetBool ("beenHit", false);
		move ();
	}

	void move(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, 0);
	}
	
	public void didEnterCreek(float slowingValue, bool enteredCreek){
		if (!inCreek) {
			moveSpeed -= slowingValue;
			move ();		
			inCreek = enteredCreek;
		}
	}

	public void didExitCreek(float additionalSpeed){
		if (inCreek) {
			moveSpeed += additionalSpeed;
			move();
			inCreek = false;
		}
	}

	void layDeadForTwoSeconds(){
		gameObject.GetComponent<Collider2D>().enabled = false;
		showCoin ();
		Invoke ("dieAndVanish", 2);
	}
	
	void dieAndVanish() {
		Destroy (gameObject);
	}

	void showCoin(){
		coin = Instantiate (coinPrefab, transform.position, Quaternion.identity) as GameObject;
		Invoke ("destroyCoinAndAddToScore", 1);
	}
	
	void destroyCoinAndAddToScore(){
		Destroy (coin);
		ScoreLabelScript scoreLabelScript = Camera.main.GetComponent<ScoreLabelScript> ();
		scoreLabelScript.scoreChanges = score;
		scoreLabelScript.coinChanges = 1;
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
