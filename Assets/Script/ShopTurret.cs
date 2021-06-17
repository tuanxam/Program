using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class ShopTurret : MonoBehaviour
{
    public static event Action <int> Event_OnClickBuy;
    [HideInInspector] public int item_index;
    public Transform Panel;

    private Button button;
   
    void Start()
    {
        gameObject.SetActive(false);
        SetButton();
    }

    private void onShopTurretBntClicked(int index)
    {
        Event_OnClickBuy?.Invoke(index);
        Debug.Log(index);
    }

    private void SetButton()
    {
        for (int i = 0; i < Panel.GetChildCount(); i++)
        {
            button = Panel.GetChild(i).GetComponent<Button>();
            button.AddEventListener(i, onShopTurretBntClicked);
        }
    }
}

