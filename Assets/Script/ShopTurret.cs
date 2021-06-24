using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class ShopTurret : MonoBehaviour
{
    public event Action <int> Event_OnSelectItem;
    [HideInInspector] public int item_index;
    public Transform Panel;

    private Button button;
   
    void Start()
    {
         SetButton();
    }

    private void onShopTurretBntClicked(int index)
    {
        Event_OnSelectItem?.Invoke(index);
        Debug.Log(index);
    }

    private void SetButton()
    {
        for (int i = 0; i < Panel.childCount; i++)
        {
            button = Panel.GetChild(i).GetComponent<Button>();
            button.AddEventListener(i, onShopTurretBntClicked);
        }
    }
}

