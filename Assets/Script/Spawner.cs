using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    private bool isSpawned = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawned)
        {
            StartCoroutine(SpawEnemy());
        }     
    }

    IEnumerator SpawEnemy()
    {
        isSpawned = false;
        Instantiate(enemyPrefab,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1);
        isSpawned = true;
    }
}
