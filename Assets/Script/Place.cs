using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Place : MonoBehaviour
{
    public ShopTurret shopTurret;
    public Canvas _buildcanvas;
    public SpawnerTurret spawnerTurret;
    public int placeId;
    void Start()
    {
        shopTurret.Event_OnSelectItem += Handle_EvenOnSelectItem;
    }

    private void Handle_EvenOnSelectItem(int index)
    {
        spawnerTurret.Spaw(index);
        _buildcanvas.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        _buildcanvas.gameObject.SetActive(!_buildcanvas.gameObject.activeSelf);
    }
}
