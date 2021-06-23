using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tmp_coin;
    public TextMeshProUGUI tmp_time;
    public GameObject panel_defeat;
    public GameObject panel_win;
    public Button bt_startGame;
    public Button bt_pauseGame;
    public Button bt_resumeGame;
    public Button bt_replayGame;
    public Button bt_loadMap;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);      
    }

    private void Start()
    {
        bt_startGame.onClick.AddListener(OnclickStartGame);
        bt_pauseGame.onClick.AddListener(OnclickPauseGame);
        bt_resumeGame.onClick.AddListener(OnclickResumeGame);
        bt_replayGame.onClick.AddListener(OnclickReplayGame);
        bt_loadMap.onClick.AddListener(OnclickLoadMap);
        GameManager._instance.Event_IsDefeat += Handle_Event_isDefeat;
        GameManager._instance.Event_IsWin += Handle_Event_isWin;
    }

    private void Update()
    {
        SetText(HelperCalculate._instance.coins);
        tmp_time.SetText(GameManager._instance.current_time.ToString("0,0.0"));
    } 

    private void Handle_Event_isDefeat(bool isdefeat)
    {
        if(isdefeat)
        {
            panel_defeat.SetActive(true);
        }
    }
    private void Handle_Event_isWin(bool iswin)
    {
        if (iswin)
        {
            panel_win.SetActive(true);
        }
    }

    public void SetText(int i)
    {
        tmp_coin.SetText(i.ToString());
    }

    private void OnclickLoadMap()
    {
        GameManager._instance.Event_IsWin -= Handle_Event_isWin;
        bt_startGame.gameObject.SetActive(true);
        SceneManager.LoadScene("Map1.1");             
    }

    private void OnclickReplayGame()
    {
        GameManager._instance.Event_IsDefeat -= Handle_Event_isDefeat;
        GameManager._instance.ReplayGame();
    }

    private void OnclickStartGame()
    {
        GameManager._instance.StartGame();
    }

    private void OnclickPauseGame()
    {
        GameManager._instance.PauseGame();
    }

    private void OnclickResumeGame()
    {
        GameManager._instance.ResumeGame();
    }
}
