using UnityEngine;
using System.Collections;

public class CatapultScript : MonoBehaviour {
	
	private float moveSpeed = 3.0f;
	[HideInInspector]// hides moveDirection in inspector
	public Vector3 moveDirection;
	public float damage = 10.0f;
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, moveSpeed * Time.deltaTime);

		transform.Rotate (0, 0, 10);// rotation of the stone
	}

	void OnTriggerEnter2D(Collider2D other){
		string nameOfTheObject = other.name;// get the name object been hit
		
		switch (nameOfTheObject) {// search for the object
		case "BlueArcher(Clone)":
			other.GetComponent<Animator>().SetBool("die", true);// killing animation
			break;
			
		case "BlueKnight(Clone)":
			other.GetComponent<Animator>().SetBool("die", true);
			break;
			
		case "GreenArcher(Clone)":
			other.GetComponent<Animator>().SetBool("die", true);
			break;
			
		case "GreenKnight(Clone)":
			other.GetComponent<Animator>().SetBool("die", true);
			break;
			
		case "RedArcher(Clone)":
			other.GetComponent<Animator>().SetBool("die", true);
			break;
			
		case "RedKnight(Clone)":
			other.GetComponent<Animator>().SetBool("die", true);
			break;
			
		default:
			break;
		}	

	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	} 
}
