using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Place : MonoBehaviour
{
    public ShopTurret shopTurret;
    public SpawnerTurret spawnerTurret;
    public int id;

    [SerializeField]
    private Canvas _buildCanvas;

    void Start()
    {
        shopTurret.Event_SelectTower += Handlet_Event_SelectTower;
    }

    private void Handlet_Event_SelectTower(int id)
    {
        this.id = id;
        spawnerTurret.Spaw(id);
    }

    private void OnMouseDown()
    {
        Debug.Log($"Click on place");
        _buildCanvas.gameObject.SetActive(true);
    }
}
