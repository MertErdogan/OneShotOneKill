using UnityEngine;
using System.Collections;

public class EnemyGeneratorController : MonoBehaviour {

	public float minSpawnTime = 3f;
	public float maxSpawnTime = 5f;
	public GameObject[] enemies = new GameObject[6];
	private float maxY = 0.35f;// 0.35 
	private float minY = 4.30f;// -4.30
	private float xValue = 9.30f;// -9.30

	// Use this for initialization
	void Start () {
		Invoke ("spawnEnemy", minSpawnTime);
	}

	void spawnEnemy(){
		int index = Random.Range (0, enemies.Length);
		Vector3 enemySpawnPoint = new Vector3(-xValue, Random.Range(-minY, maxY), enemies[index].transform.position.z);

		Instantiate(enemies[index], enemySpawnPoint, Quaternion.identity);
		Invoke("spawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
	}
}
