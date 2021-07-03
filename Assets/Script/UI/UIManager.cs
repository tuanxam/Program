using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
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
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);      
    }

    private void Start()
    {
        bt_startGame.onClick.AddListener(OnclickStartGame);
        bt_pauseGame.onClick.AddListener(OnclickPauseGame);
        bt_resumeGame.onClick.AddListener(OnclickResumeGame);
        bt_replayGame.onClick.AddListener(OnclickReplayGame);
        bt_loadMap.onClick.AddListener(OnclickLoadMap);
    }

    private void Update()
    {
        tmp_coin.SetText(Calculation.GetSuffix(HelperCalculate._instance.GetCoin()));
        tmp_time.SetText(GameManager._instance.current_time.ToString("0,0.0"));
    } 

    private void Handle_Event_isDefeat(bool isdefeat)
    {
         panel_defeat.SetActive(isdefeat);
    }
    private void Handle_Event_isWin(bool iswin)
    {
        panel_win.SetActive(iswin);
    }

    private void OnclickLoadMap()
    {        
        Loader._instance.LoadNextLevel();
        GameManager._instance.ResetStatus();
        bt_startGame.gameObject.SetActive(true);       
    }

    private void OnclickReplayGame()
    {       
        GameManager._instance.ReplayGame();
       // GameManager._instance.Event_IsDefeat -= Handle_Event_isDefeat;
        bt_startGame.gameObject.SetActive(true);
    }

    private void OnclickStartGame()
    {
        GameManager._instance.Event_IsDefeat += Handle_Event_isDefeat;
        GameManager._instance.Event_IsWin += Handle_Event_isWin;
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
