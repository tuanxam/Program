using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tmp_coin;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        SetText(HelperCalculate._instance.coins);
    }
    public void SetText(int i)
    {
        tmp_coin.SetText(i.ToString());
    }
}
