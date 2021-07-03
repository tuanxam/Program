using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HelperCalculate : MonoBehaviour
{
    public static HelperCalculate _instance;
    private int _coin;
    private int _gem;
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
    public void AddCoin(int coin)
    {
        _coin += coin;
    }
    public int GetCoin()
    {
        return _coin;
    }

    public void ResetCoin(int coinformap)
    {
        _coin = coinformap;
    }

    public void AddGem(int gem)
    {
        _gem += gem;
    }

    public void GetGem(int gem)
    {
        _gem -= gem;
    }
}
