using UnityEngine;
using System.Collections;

public class RedArcher : MonoBehaviour {

	[HideInInspector]
	public float moveSpeed = 0.9f;
	public float health = 3;
	public float damage = 3;
	private float attackWait = 2f;// wait 2 second before decide to attack or not, animation takes 1.5 seconds
	public int attackRate = 8;// % 20 attack, % 80 not attack 
	public GameObject arrow;
	public GameObject coinPrefab;
	private GameObject coin;
	private int score = 200;
	private bool inCreek = false;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, 0);
		Invoke ("archerAttack", attackWait);
	}

	void archerAttack() {
		int randomNumber = Random.Range (1, 10);// get random number between 1 and 10
		
		if (randomNumber >= attackRate) {
			GetComponent<Animator> ().SetBool ("openFire", true);// trigger attack animation
			Invoke("fireArrow", 1f);// wait for animation's firing gesture
		}
		Invoke ("archerAttack", attackWait);
	}
	
	void fireArrow(){
		Vector3 arrowMoveDirection = new Vector3(1,0,0);// fire to right of the scene
		GameObject firedArrow = Instantiate(arrow, transform.position, Quaternion.identity) as GameObject;
		ArrowScript arrowScript = firedArrow.GetComponent<ArrowScript>();
		arrowScript.enemyArrow = true;
		arrowScript.moveDirection = arrowMoveDirection;
	}

	void stopForAnimation(){
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
	}
	
	void beginWalkingAgain() {
		GetComponent<Animator> ().SetBool ("beenHit", false);
		GetComponent<Animator> ().SetBool ("openFire", false);// stop attack animation 
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
