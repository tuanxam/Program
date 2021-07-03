using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    public static Loader _instance;
    public Animator animator;
    public Canvas canvasAnimation;
    public float transitionTime;
    private WaitForSeconds wait;
    [HideInInspector] public int currentScene;

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

    public void LoadNextLevel()
    {
        wait = new WaitForSeconds(transitionTime);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        GameManager._instance.currenLevel++;
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(currentScene));
    }

    IEnumerator LoadLevel(int index)
    {
        animator.SetTrigger("Start");
        yield return wait;
        SceneManager.LoadScene(index);
    }
}
