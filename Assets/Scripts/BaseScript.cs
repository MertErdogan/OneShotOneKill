using UnityEngine;
using System.Collections;

public class BaseScript : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "arrow(Clone)") {//an arrow is collide with base
			if (other.GetComponent<ArrowScript>().enemyArrow){//an enemy arrow collide with base
				Camera.main.GetComponent<Progress>().baseHealth -= other.GetComponent<ArrowScript>().damage;
				Destroy(other.gameObject);
			}
		} else {
			string nameOfTheObject = other.name;// get the name object been hit

			switch (nameOfTheObject) {// search for the collider object
			case "BlueArcher(Clone)":
					Camera.main.GetComponent<Progress>().baseHealth -= other.GetComponent<BlueArcher>().damage;
					Destroy (other.gameObject);// destroy the arrow once it hit some enemy
					break;
				
			case "BlueKnight(Clone)":
					Camera.main.GetComponent<Progress>().baseHealth -= other.GetComponent<BlueKnight>().damage;
					Destroy (other.gameObject);
					break;
				
			case "GreenArcher(Clone)":
					Camera.main.GetComponent<Progress>().baseHealth -= other.GetComponent<GreenArcher>().damage;
					Destroy (other.gameObject);
					break;
				
			case "GreenKnight(Clone)":
					Camera.main.GetComponent<Progress>().baseHealth -= other.GetComponent<GreenKnight>().damage;	
					Destroy (other.gameObject);
					break;
				
			case "RedArcher(Clone)":
					Camera.main.GetComponent<Progress>().baseHealth -= other.GetComponent<RedArcher>().damage;
					Destroy (other.gameObject);
					break;
				
			case "RedKnight(Clone)":
					Camera.main.GetComponent<Progress>().baseHealth -= other.GetComponent<RedKnight>().damage;
					Destroy (other.gameObject);
					break;
				
				default:
					break;
			}		
		}
	}
}
