using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour {

	public float fullBaseHealth = 100f;// undamaged base health 
	public float baseHealth = 100f;// current base health
	public float fullBarricadeHealth = 50f;// undamaged barricade health
	public float barricadeHealth = 50f;// current barricade health
	
	private GUIStyle currentStyle = null;

	[HideInInspector]
	public bool barricadeMode = false;

	private float barDisplay;
	private float barricadeDisplay;

	void OnGUI()
	{	
		InitStyles();
		if (barricadeMode) {
			// outer box of health bar
			GUI.Box (new Rect (10, 10, (Screen.width/4), (Screen.height/9)), "Barricade");
			
			// health bar box
			GUI.Box (new Rect (20, 40, (Screen.width / 4 - 20) * barricadeDisplay, 20), "bar", currentStyle);
		} else {
			// outer box of health bar
			GUI.Box (new Rect (10, 10, (Screen.width/4), (Screen.height/9)), "Health bar");
			
			// health bar box
			GUI.Box (new Rect (20, 40, (Screen.width / 4 - 20) * barDisplay, 20), "bar", currentStyle);
		}


	}

	void Update()
	{
		// the base's health
		if (barDisplay >= 0) {
			barDisplay = baseHealth / fullBaseHealth;// get base's current health and calculate health bar		
		} else {
			Application.LoadLevel("GameOverScene");
		}

		// the barricade's health
		if (barricadeDisplay >= 0) {
			barricadeDisplay = barricadeHealth / fullBarricadeHealth;// get barricade's current health and calculate bar
		} else {
			barricadeMode = false;
			BarricadeScript barricadeScript = GameObject.FindWithTag("Barricade").GetComponent<BarricadeScript>();
			barricadeScript.destroyBarricade();
		}


	}
//------------------------------------------------------------------------------------------------
	private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );

			currentStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
		}
	}
	
	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
//---------------------------------------------------------------------------------------------------
}
