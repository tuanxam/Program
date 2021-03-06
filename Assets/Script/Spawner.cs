using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Enemy> list_enemyPrefab = new List<Enemy>();
    public List<EnemyData> list_enemyData = new List<EnemyData>();
    //private List<Enemy> enemyPool = new List<Enemy>();
    private Coroutine _coroutine;
    private WayPoint _wayPoint;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
       
    }

    public void StartSpawEnemy()
    {
        _wayPoint = GameObject.FindGameObjectWithTag("WayPoint").GetComponent<WayPoint>();       
        transform.position = _wayPoint.transform.position;
        _coroutine = StartCoroutine(SpawEnemy());
        Debug.Log("start");
    }

    public void StopSpawEnemy()
    {
        StopCoroutine(_coroutine);
    }

    IEnumerator SpawEnemy()
    {
        while(true)
        {
            Enemy enemy = Instantiate(list_enemyPrefab[GameManager._instance.currenLevel]);
           // Enemy enemy = GetEnemyFromPool();
            EnemyData data = list_enemyData[0];
            enemy.transform.position = transform.position;
            enemy.hp = data.hp;
            enemy.def = data.def;
            enemy.speed = data.move_speed;
            enemy.enemyCoin = data.coin;
            enemy.current_hp = enemy.hp;
            enemy._wayPoint = _wayPoint;
            yield return new WaitForSeconds(1);
        }       
    }

    //Enemy GetEnemyFromPool()
    //{
    //    foreach (Enemy g in enemyPool)
    //    {
    //        if (g.gameObject.activeSelf == false)
    //            return g;
    //    }

    //    var new_enemy = Instantiate(list_enemyPrefab[0]);
    //    enemyPool.Add(new_enemy);
    //    return new_enemy;
    //}
}
