﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerLaser : MonoBehaviour {


    public GameObject Hazards;
    public Vector3 SpawnValues;
    public int hazardCount;
    public Transform SpawnLocation1;
    GameObject NewHazards;
   // public Transform SpawnLocation2;
   // public Transform SpawnLocation3;
   // public Transform SpawnLocation4;
   // public Transform SpawnLocation5;
   // public Transform SpawnLocation6;
   // public Transform SpawnLocation7;
   // public Transform SpawnLocation8;
   // public Transform SpawnLocation9;
   // public Transform SpawnLocation10;
   // public Transform SpawnLocation11;
   // private Transform Reallocation;
    public float spawnWaitMin;
    public float spawnWaitMax;
    public float startWait;
    public float waveWait;
    private float spawnWaitbefore;
   
    private void Start()
    {
        
     //   Array = new Transform[11];
     //   Array[0] = SpawnLocation1;
     //   Array[1] = SpawnLocation2;
      //  Array[2] = SpawnLocation3;
       // Array[3] = SpawnLocation4;
      //Array[4] = SpawnLocation5;
       // Array[5] = SpawnLocation6;
       // Array[6] = SpawnLocation7;
       // Array[7] = SpawnLocation8;
      //  Array[8] = SpawnLocation9;
      //  Array[9] = SpawnLocation10;
      //  Array[10] = SpawnLocation11;

        StartCoroutine (SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                // Reallocation = Array[Random.Range(0, 10)];
                
                float spawnWait = Random.Range(spawnWaitMin, spawnWaitMax);
                while (spawnWait == spawnWaitbefore) {
                    for (int a = 0; a < hazardCount; a++)
                        spawnWait = Random.Range(spawnWaitMin, spawnWaitMax);
                    }
                
               
                Vector3 spawnPosition = new Vector3(SpawnLocation1.transform.position.x, SpawnLocation1.transform.position.y
                , SpawnLocation1.transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                NewHazards = Instantiate(Hazards, spawnPosition, spawnRotation);
                NewHazards.transform.parent = transform;
                yield return new WaitForSeconds(spawnWait);
                spawnWaitbefore = spawnWait;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}

