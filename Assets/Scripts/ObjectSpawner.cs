using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

	public int spawnAmount;
	public float spawnRate;
	public Transform[] spawnPoints;
	public GameObject spawnedObject;
	public bool isEnemySpawner;
	
	private float nextSpawn;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((spawnAmount > 0 && isEnemySpawner) || !isEnemySpawner) {
			if (Time.time > nextSpawn) {
				Instantiate(spawnedObject, spawnPoints[Random.Range(0, spawnPoints.Length)].position, spawnPoints[Random.Range(0, spawnPoints.Length)].rotation);
				nextSpawn = Time.time + spawnRate;
				spawnAmount--;
			}
		}
		
	}
}
