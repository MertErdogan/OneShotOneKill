using UnityEngine;
using System.Collections;

public class CreekButton : MonoBehaviour {
	
	private float x = 30 + Screen.width/4;
	private float y = 10f;
	private float width = Screen.width/8;
	private float height = Screen.height/19;
	private float creekX = 0.02942934f;
	private float creekY = 0.4965973f;//-0.4965973
	private float creekZ = 0f;
	public GameObject creek;
	private bool creekOn = false;
	private int creekCost = 2;
	[HideInInspector]
	public int coins;

	void OnGUI () {
		if (GUI.Button (new Rect (x, y, width, height), "Creek")) {
			// check if player has enough coins to purchase creek
			if(coins >= creekCost){
				// if creek is off and button clicked then create creek
				if(!creekOn){
					Vector3 creekSpawnPoint = new Vector3(creekX, -creekY, creekZ);// spawn point
					Instantiate(creek, creekSpawnPoint, Quaternion.identity);// instantiate creek
					ScoreLabelScript scoreLabelScript = Camera.main.GetComponent<ScoreLabelScript> ();
					scoreLabelScript.coinChanges = -creekCost;
					creekOn = true;
					creekCost += 2;
				} else {
					// if creek is on and button clicked then deepen the creek(decrease more speed)
					CreekScript creekScript = GameObject.FindWithTag("Creek").GetComponent<CreekScript>();
					if (creekScript.speedDecrease < 0.6){ // knight min. speed = 0.1, archer min. speed = 0.3
						creekScript.speedDecrease += 0.2f;
						ScoreLabelScript scoreLabelScript = Camera.main.GetComponent<ScoreLabelScript> ();
						scoreLabelScript.coinChanges = -creekCost;
						creekCost += 2;
					}
				}
			}
		}
	}
}
