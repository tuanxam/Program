using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class CanvasUpgrade : MonoBehaviour
{
    public event Action <int> Event_OnClickCanvasUpgrade;
    [HideInInspector] public Turret turret;
    public Transform panel;
    private Button _button;

    private void Start()
    {
        SetUpButton();
    }

    private void OnClickedUpdrade (int index)
    {
        switch(index)
        {
            case 0:
                Event_OnClickCanvasUpgrade?.Invoke(0);
                Debug.Log("click upgrade");
                break;
            case 1:
                Event_OnClickCanvasUpgrade?.Invoke(1);
                Debug.Log("click sell");
                break;
        }
        gameObject.SetActive(false);
    }
    private void SetUpButton()
    {
        for (int i = 0; i < panel.childCount; i++)
        {
            _button = panel.GetChild(i).GetComponent<Button>();
            _button.AddEventListener(i, OnClickedUpdrade);          
        }
    }

    public void SetTextCostUpgrade()
    {
        _button = panel.GetChild(0).GetComponent<Button>();
        _button.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(turret.cost_upgrade.ToString());              
    }

}
