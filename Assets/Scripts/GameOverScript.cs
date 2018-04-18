using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	private float x = Screen.width/3;
	private float y = Screen.height/2;
	private float width = Screen.width/5;
	private float height = Screen.height/10;
	
	void OnGUI(){
		GUI.backgroundColor = Color.blue;
		if (GUI.Button (new Rect (x, y, width, height), "ONE MORE TIME")) {
			Application.LoadLevel("mainScene");
		}
	}
}
