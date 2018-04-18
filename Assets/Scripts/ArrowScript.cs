using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	private float moveSpeed = 5.0f;
	[HideInInspector]// hides moveDirection in inspector
	public Vector3 moveDirection;
	public float damage = 2.0f;
	[HideInInspector]
	public bool enemyArrow = false;// did enemy used this arrow or the player
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (enemyArrow) {
			//damaging the base done in "baseScript"
		} else {
			string nameOfTheObject = other.name;// get the name object been hit
			float objectHealth;
			
			switch (nameOfTheObject) {// search for the object
			case "BlueArcher(Clone)":
				objectHealth = other.GetComponent<BlueArcher>().health;
				objectHealth -= damage;// get health of the object and subtract the damage
				if (objectHealth <= 0) {// check if it should die
					other.GetComponent<Animator>().SetBool("die", true);// killing animation
				} else {
					other.GetComponent<Animator>().SetBool("beenHit", true);// hitting animation
				}
				other.GetComponent<BlueArcher>().health = objectHealth;// update the object's health
				Destroy (gameObject);// destroy the arrow once it hit some enemy
				break;
				
			case "BlueKnight(Clone)":
				objectHealth = other.GetComponent<BlueKnight>().health;
				objectHealth -= damage;
				if (objectHealth <= 0) {
					other.GetComponent<Animator>().SetBool("die", true);
				} else {
					other.GetComponent<Animator>().SetBool("beenHit", true);
				}
				other.GetComponent<BlueKnight>().health = objectHealth;
				Destroy (gameObject);
				break;
				
			case "GreenArcher(Clone)":
				objectHealth = other.GetComponent<GreenArcher>().health;
				objectHealth -= damage;
				if (objectHealth <= 0) {
					other.GetComponent<Animator>().SetBool("die", true);
				} else {
					other.GetComponent<Animator>().SetBool("beenHit", true);
				}
				other.GetComponent<GreenArcher>().health = objectHealth;
				Destroy (gameObject);
				break;
				
			case "GreenKnight(Clone)":
				objectHealth = other.GetComponent<GreenKnight>().health;
				objectHealth -= damage;
				if (objectHealth <= 0) {
					other.GetComponent<Animator>().SetBool("die", true);
				} else {
					other.GetComponent<Animator>().SetBool("beenHit", true);
				}
				other.GetComponent<GreenKnight>().health = objectHealth;
				Destroy (gameObject);
				break;
				
			case "RedArcher(Clone)":
				objectHealth = other.GetComponent<RedArcher>().health;
				objectHealth -= damage;
				if (objectHealth <= 0) {
					other.GetComponent<Animator>().SetBool("die", true);
				} else {
					other.GetComponent<Animator>().SetBool("beenHit", true);
				}
				other.GetComponent<RedArcher>().health = objectHealth;
				Destroy (gameObject);
				break;
				
			case "RedKnight(Clone)":
				objectHealth = other.GetComponent<RedKnight>().health;
				objectHealth -= damage;
				if (objectHealth <= 0) {
					other.GetComponent<Animator>().SetBool("die", true);
				} else {
					other.GetComponent<Animator>().SetBool("beenHit", true);
				}
				other.GetComponent<RedKnight>().health = objectHealth;
				Destroy (gameObject);
				break;
				
			default:
				break;
			}		
		}
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	} 
}
