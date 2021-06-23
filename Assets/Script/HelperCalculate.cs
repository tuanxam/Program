using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HelperCalculate : MonoBehaviour
{
    public static HelperCalculate _instance;
    public int coins;

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
    public void AddCoin(int _coin)
    {
        coins += _coin;
    }
    public void GetCoin(int _coin)
    {
        coins -= _coin;
    }
  
}
