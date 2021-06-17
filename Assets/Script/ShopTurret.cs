using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class ShopTurret : MonoBehaviour
{
    public static event Action <int> Event_OnSelectItem;
    [HideInInspector] public int item_index;
    public Transform Panel;

    public Button button;
   
    void Start()
    {
        // SetButton();
        button.onClick.AddListener(onickBuy);
    }

    void onickBuy()
    {
        item_index = 1;
        Event_OnSelectItem?.Invoke(item_index);
    }
    private void onShopTurretBntClicked(int index)
    {
        Event_OnSelectItem?.Invoke(index);
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

