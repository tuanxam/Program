using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class ShopTurret : MonoBehaviour
{
    public static event Action <int> Event_OnClickBuy;
    public Button slot1, slot2, slot3, slot4;
    [HideInInspector]
    public int item;

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
        item = 1;
        Event_OnClickBuy?.Invoke(item);
    }

    public void OnClickBuy_2()
    {
        item = 2;
        Event_OnClickBuy?.Invoke(item);
    }

    public void OnClickBuy_3()
    {
        item = 3;
        Event_OnClickBuy?.Invoke(item);

    }
    public void OnClickBuy_4()
    {
        item = 4;
        Event_OnClickBuy?.Invoke(item);
    }

   
}

