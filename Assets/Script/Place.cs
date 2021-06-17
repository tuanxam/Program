using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Place : MonoBehaviour
{
    public static event Action<int> Event_OnClickPlace;
    public GameObject shopTurret;
    public Canvas _buildcanvas;
    void Start()
    {
       
    }

    // Update is called once per frame


    private void OnMouseDown()
    {
        _buildcanvas.gameObject.SetActive(!_buildcanvas.gameObject.activeSelf);
        Debug.Log("onlick");
    }
}
