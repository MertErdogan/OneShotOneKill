using UnityEngine;
using System.Collections;

public class DefensiveScript : MonoBehaviour {

	public GameObject[] weapons = new GameObject[2];
	private float maxY = 0.07f;// 0.07 for arrow spawn point
	private float minY = 4.30f;// -4.30 for arrow spawn point
	private float xValue = 9.50f;// -9.50 for arrow spawn point
	private Vector3 moveDirection;// will send to arrow
	public float weaponFireRate = 1.0f;// will change according to player's score
	private bool canFire = true;
	private GameObject weapon;
	private bool arrowOn = true;

	// Use this for initialization
	void Start () {
		weapon = weapons [0];
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 weaponSpawnPoint = new Vector3(xValue, Random.Range(-minY, maxY), weapon.transform.position.z);
		Vector3 moveToward;

		if (canFire) {
			if (Input.GetButton ("Fire1")) {

				moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				moveToward.z = 0;
				moveDirection = moveToward - weaponSpawnPoint;
				moveDirection.Normalize();
				Quaternion rotation = Quaternion.Euler( 0, 
				                             0, 
				                             Mathf.Atan2 ( -moveDirection.y, -moveDirection.x ) * Mathf.Rad2Deg );
				if (arrowOn){
					GameObject arrow = Instantiate( weapon, weaponSpawnPoint, rotation) as GameObject;
					ArrowScript arrowScript = arrow.GetComponent <ArrowScript>();
					arrowScript.moveDirection = moveDirection;
				} else {
					GameObject catapult = Instantiate( weapon, weaponSpawnPoint, rotation) as GameObject;
					CatapultScript catapultScript = catapult.GetComponent <CatapultScript>();
					catapultScript.moveDirection = moveDirection;
				}


				holdFire();
				Invoke("openFire", weaponFireRate);
			}
		}

	}

	public void changeWeapon(int index){
		weapon = weapons [index];
		arrowOn = !arrowOn;
	}

	void holdFire(){
		canFire = false;
	}

	void openFire(){
		canFire = true;
	}
}
