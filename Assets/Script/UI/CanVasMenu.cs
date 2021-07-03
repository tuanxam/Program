using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CanVasMenu : MonoBehaviour
{
    public Button bt_meneu;
    public Button bt_startGame;
    public Button bt_exit;
    public Button bt_setting;
    void Start()
    {
        bt_startGame.onClick.AddListener(OnclickStartGame);
        bt_exit.onClick.AddListener(OnclickExitGame);
    }

    private void OnclickStartGame()
    {
        Loader._instance.LoadNextLevel();
    }

    private void OnclickExitGame()
    {
        Application.Quit();
    }
}
