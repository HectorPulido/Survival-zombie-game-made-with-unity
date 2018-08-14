using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour 
{

	public Transform[] spawnPoints;
	public GameObject[] spawnPrefab;
	public float spawnTime;

	float count;
	void Update () 
	{
		count += Time.deltaTime;

		if(count >= spawnTime)	
		{
			count = 0;
			Instantiate(spawnPrefab[Random.Range(0,spawnPrefab.Length)],
				spawnPoints[Random.Range(0, spawnPoints.Length)].position,
				Quaternion.identity);
		}
	}
}
