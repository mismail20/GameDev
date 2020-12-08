using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployObstacle : MonoBehaviour {
    public GameObject prefab1, prefab2;



    // Use this for initialization
    void Start () {

        StartCoroutine(obstacleWave());
    }
    private void spawnEnemy(){

      int whatToSpawn;
      whatToSpawn = Random.Range (1,3); // Random selection of which obstacles which can be expanded
      Debug.Log (whatToSpawn);

      switch (whatToSpawn) {
        case 1:
          GameObject a = Instantiate(prefab1) as GameObject; //Creation of game objects
          break;
        case 2:
          GameObject b = Instantiate(prefab2) as GameObject;
          break;
      }


    }
    IEnumerator obstacleWave(){
        while(true){
            yield return new WaitForSeconds(2f);
            spawnEnemy();
        }
    }
}
