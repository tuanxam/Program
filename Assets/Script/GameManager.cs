using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public event Action<bool> Event_IsDefeat;
    public event Action<bool> Event_IsWin;
    public Coroutine coroutine;
    public Place place;
    public float timeDef;
    public int life;
    public Spawner spawnerEnemy;
    private bool _isDeFeat, _isWin;
    [HideInInspector] public int current_life;
    [HideInInspector] public float current_time;
    [HideInInspector] public int currenLevel;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        current_life = life;
        current_time = timeDef;
    }

    // Update is called once per frame
    void Update()
    {
        EndLife();
        WinWave();
    }

    IEnumerator CountTime()
    {
        while(true)
        {
            current_time -= Time.deltaTime;
            yield return null;
        }
    }

    public void EndLife()
    {
        if(current_life <= 0)
        {
            StopGame();
            _isDeFeat = true;
            Event_IsDefeat?.Invoke(_isDeFeat);
            Debug.Log(_isDeFeat);
        }
    }

    public void WinWave()
    {
        if(current_life > 0 && current_time <= 0)
        {
            _isWin = true;
            Event_IsWin?.Invoke(_isWin);
            StopGame();
            Debug.Log(_isWin);
        }
    }

    public void StartGame()
    {
        Debug.Log("start game");
        ResetStatus();
        
        coroutine = StartCoroutine(CountTime());
        spawnerEnemy.StartSpawEnemy();

    }

    public void ResetStatus()
    {
        _isWin = false;
        _isDeFeat = false;
        Event_IsWin?.Invoke(_isWin);
        Event_IsDefeat?.Invoke(_isDeFeat);

        HelperCalculate._instance.ResetCoin(100);
        current_time = timeDef;
        current_life = life;
    }

    public void StopGame()
    {
        StopCoroutine(coroutine);
        spawnerEnemy.StopSpawEnemy();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }


    public void ReplayGame()
    {
        ResetStatus();
        Loader._instance.ReloadLevel();       
    }
}
