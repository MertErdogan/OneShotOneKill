using UnityEngine;
using System.Collections;

public class BarricadeButton : MonoBehaviour {
	
	private float x = 30 + Screen.width/4;
	private float y = 12 + Screen.height/18;
	private float width = Screen.width/8;
	private float height = Screen.height/19;
	private float barricadeX = 0.02942934f;
	private float barricadeY = 0.4965973f;//-0.4965973
	private float barricadeZ = 0f;
	public GameObject barricade;
	[HideInInspector]
	public bool barricadeOn = false;
	private int barricadeCost = 2;
	[HideInInspector]
	public int coins;

	void OnGUI () {
		if (GUI.Button (new Rect (x, y, width, height), "Barricade")) {
			// check if the player has enough coins to purchase barricade
			if(coins >= barricadeCost){
				// if barricade is off and button clicked then create barricade
				if (!barricadeOn) {
					Vector3 barricadeSpawnPoint = new Vector3(barricadeX, -barricadeY, barricadeZ);// spawn point
					Instantiate(barricade, barricadeSpawnPoint, Quaternion.identity);// instantiate barricade
					ScoreLabelScript scoreLabelScript = Camera.main.GetComponent<ScoreLabelScript> ();
					scoreLabelScript.coinChanges = -barricadeCost;
					barricadeOn = true;// change the mode
					barricadeCost += 2;
					Camera.main.GetComponent<Progress>().barricadeMode = true;
				} else {
					// if barricade on and button clicked then fortify the barricade(+50 hit points)
					Camera.main.GetComponent<Progress>().fullBarricadeHealth += 50;
					Camera.main.GetComponent<Progress>().barricadeHealth += 50;
					ScoreLabelScript scoreLabelScript = Camera.main.GetComponent<ScoreLabelScript> ();
					scoreLabelScript.coinChanges = -barricadeCost;
					barricadeCost += 2;
				}
			}
		}
	}
}
