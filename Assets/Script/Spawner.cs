using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private List<GameObject> enemyPool = new List<GameObject>();
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
        var enemy = GetEnemyFromPool();
        enemy.SetActive(true);
        enemy.transform.position = transform.position;
        yield return new WaitForSeconds(1);
        isSpawned = true;
    }

   GameObject GetEnemyFromPool()
    {
        foreach(GameObject g in enemyPool)
        {
            if (g.activeSelf == false)
                return g;
        }

        var new_enemy = Instantiate(enemyPrefab);
        enemyPool.Add(new_enemy);
        return new_enemy;
    }
}
