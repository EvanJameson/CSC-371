﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Pradeep Sangli
public class EnemySpawner : MonoBehaviour {
	public GameObject EnemyGO;
	
	float maxSpawnRateInSeconds = 5f;
	
	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		
		InvokeRepeating("IncreaseSpawnRate",0f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SpawnEnemy(){
		int temp = Random.Range(1,10);
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));
		
		GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
		anEnemy.transform.position = new Vector2 (min.x, Random.Range(min.y,max.y));
		
		ScheduleNextEnemySpawn();
	}
	
	void ScheduleNextEnemySpawn(){
		float spawnInNSeconds;
		if(maxSpawnRateInSeconds > 1f){
			spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
		}
		else{
			spawnInNSeconds = 1f;
		}
		Invoke ("SpawnEnemy", spawnInNSeconds);
	}
	
	void IncreaseSpawnRate(){
		if(maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if(maxSpawnRateInSeconds == 1f){
			CancelInvoke("IncreaseSpawnRate");
		}
	}
}
