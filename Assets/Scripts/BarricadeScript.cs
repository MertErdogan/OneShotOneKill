using UnityEngine;
using System.Collections;

public class BarricadeScript : MonoBehaviour {

	public void destroyBarricade(){
		Destroy (gameObject);
		BarricadeButton barricadeButton = Camera.main.GetComponent<BarricadeButton>();
		barricadeButton.barricadeOn = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "arrow(Clone)") {//an arrow is collide with barricade
			if (other.GetComponent<ArrowScript>().enemyArrow){//an enemy arrow collide with barricade
				Camera.main.GetComponent<Progress>().barricadeHealth -= other.GetComponent<ArrowScript>().damage;
				Destroy(other.gameObject);
			}
		} else {
			string nameOfTheObject = other.name;// get the name object been hit
			
			switch (nameOfTheObject) {// search for the collider object
			case "BlueArcher(Clone)":
					Camera.main.GetComponent<Progress>().barricadeHealth -= other.GetComponent<BlueArcher>().damage;
					Destroy (other.gameObject);// destroy the arrow once it hit some enemy
					break;
				
			case "BlueKnight(Clone)":
					Camera.main.GetComponent<Progress>().barricadeHealth -= other.GetComponent<BlueKnight>().damage;
					Destroy (other.gameObject);
					break;
				
			case "GreenArcher(Clone)":
					Camera.main.GetComponent<Progress>().barricadeHealth -= other.GetComponent<GreenArcher>().damage;
					Destroy (other.gameObject);
					break;
				
			case "GreenKnight(Clone)":
					Camera.main.GetComponent<Progress>().barricadeHealth -= other.GetComponent<GreenKnight>().damage;	
					Destroy (other.gameObject);
					break;
				
			case "RedArcher(Clone)":
					Camera.main.GetComponent<Progress>().barricadeHealth -= other.GetComponent<RedArcher>().damage;
					Destroy (other.gameObject);
					break;
				
			case "RedKnight(Clone)":
					Camera.main.GetComponent<Progress>().barricadeHealth -= other.GetComponent<RedKnight>().damage;
					Destroy (other.gameObject);
					break;
				
				default:
					break;
			}		
		}
	}
}
