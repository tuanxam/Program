using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Place : MonoBehaviour
{
    public static event Action<int> Event_OnClickPlace;
    public Button bt_build;
    public GameObject shopTurret;
    public int id;
    void Start()
    {
        bt_build.onClick.AddListener(OnclickBuild);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnclickBuild()
    {
        shopTurret.transform.position = transform.position;
        shopTurret.SetActive(true);
        Event_OnClickPlace?.Invoke(id);
    }

    private void OnMouseDown()
    {
        Debug.Log($"Click on place: {id}");
        OnclickBuild();
        ShopTurret.OnClickBuy(id);
    }
}
