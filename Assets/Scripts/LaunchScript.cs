using UnityEngine;
using System.Collections;

public class LaunchScript : MonoBehaviour {

	private float x = Screen.width/2 - Screen.width/10;
	private float y = Screen.height/15;
	private float width = Screen.width/5;
	private float height = Screen.height/10;

	void OnGUI(){
		GUI.backgroundColor = Color.red;
		if (GUI.Button (new Rect (x, y, width, height), "FIGHT")) {
			Application.LoadLevel("mainScene");
		}
	}
}
