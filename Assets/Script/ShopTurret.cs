using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class ShopTurret : MonoBehaviour
{
    public event Action<int> Event_SelectTower;
    public Button slot1, slot2, slot3, slot4;

    [HideInInspector]
    public int item;

    [SerializeField]
    private Canvas _buildCanvas;

    void Start()
    {
        slot1.onClick.AddListener(OnClickBuy_1);
        slot2.onClick.AddListener(OnClickBuy_2);
        slot3.onClick.AddListener(OnClickBuy_3);
        slot4.onClick.AddListener(OnClickBuy_4);
    }

    //cái này là tui set tay, những nếu có nhiều hơn item và t muốn tạo 1 cái scrollview thì làm sao để biết
    //khi click vào item thì sẻ cho ra giá trị của item đó, rồi truyền giá trị đó qua Spawner để nó biết mà tạo turret tương ứng

    public void OnClickBuy_1()
    {
        _buildCanvas.gameObject.SetActive(false);
        item = 1;
        Event_SelectTower?.Invoke(item);
    }

    public void OnClickBuy_2()
    {
        _buildCanvas.gameObject.SetActive(false);
        item = 2;
        Event_SelectTower?.Invoke(item);
    }

    public void OnClickBuy_3()
    {
        _buildCanvas.gameObject.SetActive(false);
        item = 3;
        Event_SelectTower?.Invoke(item);
    }

    public void OnClickBuy_4()
    {
        _buildCanvas.gameObject.SetActive(false);
        item = 4;
        Event_SelectTower?.Invoke(item);
    }
}

