using UnityEngine;
using System.Collections;

public class WeaponButton : MonoBehaviour {
	
	private float x = 40 + Screen.width/4 + Screen.width/8;
	private float y = 10f;
	private float width = Screen.width/8;
	private float height = Screen.height/19;
	private bool arrowOn = true;// true: fire arrow, false: fire catapult

	void OnGUI () {
		if (GUI.Button (new Rect (x, y, width, height), "Catapult")) {
			DefensiveScript defensiveScript = GameObject.FindWithTag("DefenceGenerator").GetComponent<DefensiveScript>();
			arrowOn = !arrowOn;// change weapon 
			if (arrowOn){
				defensiveScript.changeWeapon(0);
			} else {
				defensiveScript.changeWeapon(1);
			}
		}
	}
}
