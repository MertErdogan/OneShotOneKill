using UnityEngine;
using System.Collections;

public class ScoreLabelScript : MonoBehaviour {
	
	private float x = Screen.width - (Screen.width/8) - 10;
	private float y = 10f;
	private float width = Screen.width/8;
	private float height = Screen.height/19;
	private int score = 0;
	private int coins = 0;
	[HideInInspector]
	public int scoreChanges;
	[HideInInspector]
	public int coinChanges;

	void OnGUI () {
		// outer box for score label
		GUI.Box (new Rect ( x, y, width, height + 20), "Score");
		// label for score
		GUI.Label (new Rect (x + 10, y + 20 , width - 10, height - 10), score.ToString());
		// outer box for coin label
		GUI.Box (new Rect ( x - width - 10, y, width, height + 20), "Coins");
		// label for coin
		GUI.Label (new Rect (x + 10 - width - 10, y + 20 , width - 10, height - 10), coins.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		// if there is a change in the score or coin, change the score or coin then clear the change
		if (scoreChanges != 0) {
			score += scoreChanges;
			scoreChanges = 0;		
		}
		if (coinChanges != 0) {
			coins += coinChanges;
			CreekButton creekbutton = Camera.main.GetComponent<CreekButton>();
			BarricadeButton barricadebutton = Camera.main.GetComponent<BarricadeButton>();
			creekbutton.coins = coins;
			barricadebutton.coins = coins;
			coinChanges = 0;		
		}
	}
}
