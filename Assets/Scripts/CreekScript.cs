using UnityEngine;
using System.Collections;

public class CreekScript : MonoBehaviour {

	public float speedDecrease = 0.2f;

	// when an enemy enters the trigger(creek), slows down 
	void OnTriggerEnter2D(Collider2D other){
		string nameOfTheObject = other.name;// get the name object been hit

		switch (nameOfTheObject) {// search for the collider object
		case "BlueArcher(Clone)":
			other.GetComponent<BlueArcher>().didEnterCreek(speedDecrease, true);
			break;
				
		case "BlueKnight(Clone)":
			other.GetComponent<BlueKnight>().didEnterCreek(speedDecrease, true);
			break;
				
		case "GreenArcher(Clone)":
			other.GetComponent<GreenArcher>().didEnterCreek(speedDecrease, true);
			break;
				
		case "GreenKnight(Clone)":
			other.GetComponent<GreenKnight>().didEnterCreek(speedDecrease, true);
			break;
				
		case "RedArcher(Clone)":
			other.GetComponent<RedArcher>().didEnterCreek(speedDecrease, true);
			break;
				
		case "RedKnight(Clone)":
			other.GetComponent<RedKnight>().didEnterCreek(speedDecrease, true);
			break;
				
		default:
			break;
		}		

	}

	// when an enemy exits the trigger(creek), regains the speed it lost
	void OnTriggerExit2D(Collider2D other){
		string nameOfTheObject = other.name;// get the name object been hit
		
		switch (nameOfTheObject) {// search for the collider object
		case "BlueArcher(Clone)":
			other.GetComponent<BlueArcher>().didExitCreek(speedDecrease);
			break;
			
		case "BlueKnight(Clone)":
			other.GetComponent<BlueKnight>().didExitCreek(speedDecrease);
			break;
			
		case "GreenArcher(Clone)":
			other.GetComponent<GreenArcher>().didExitCreek(speedDecrease);
			break;
			
		case "GreenKnight(Clone)":
			other.GetComponent<GreenKnight>().didExitCreek(speedDecrease);
			break;
			
		case "RedArcher(Clone)":
			other.GetComponent<RedArcher>().didExitCreek(speedDecrease);
			break;
			
		case "RedKnight(Clone)":
			other.GetComponent<RedKnight>().didExitCreek(speedDecrease);
			break;
			
		default:
			break;
		}	
	}
}
