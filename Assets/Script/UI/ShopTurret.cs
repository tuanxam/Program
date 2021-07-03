using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using TMPro;
public class ShopTurret : MonoBehaviour
{
    public event Action <int> Event_OnSelectItem;
    [HideInInspector] public int item_index;
    public Transform Panel;
    public Place _place;
    private Button _button;
    private TurretData _turretData;
    void Start()
    {
        SetButton();
    }

    private void onShopTurretBntClicked(int index)
    {
        Event_OnSelectItem?.Invoke(index);
    }

    private void SetButton()
    {
        for (int i = 0; i < Panel.childCount; i++)
        {
            _turretData = _place.list_turretDatas[i];
            _button = Panel.GetChild(i).GetComponent<Button>();
            _button.AddEventListener(i, onShopTurretBntClicked);
            _button.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(_turretData.cost.ToString());
        }
    }
}

