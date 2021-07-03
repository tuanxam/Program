using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Place : MonoBehaviour
{
    public List<Turret> list_turretPrefab = new List<Turret>();
    public List<TurretData> list_turretDatas = new List<TurretData>();
    public ShopTurret shopTurret;
    public CanvasUpgrade canvasUpgrade;
    public Canvas _buildcanvas;
    public GameObject spr1, spr2;
    [HideInInspector] public Turret turret;
    private bool _isActive;
    private bool _isbuild;
    void Start()
    {
        shopTurret.Event_OnSelectItem += Handle_EvenOnSelectItem;
        canvasUpgrade.Event_OnClickCanvasUpgrade += Handle_EventOnUpGrade;

        TouchController.Event_TouchObject += Handle_Event_TouchObject;
        TouchController.Event_TouchBackGround += Handle_Event_TouchBackGround;
    }

    private void Handle_EvenOnSelectItem(int index)
    {
        if(_isbuild == false)
        {
            Spaw(index);
            if (HelperCalculate._instance.GetCoin() >= turret.cost)
            {
                HelperCalculate._instance.AddCoin(-turret.cost);
                turret.total_cost_bouhgt = turret.cost;
                turret.Event_OnClickTurret += Handle_EventOnclicTurret;
                _isbuild = true;
                _isActive = false;
                SetActive(_isbuild);
            }
            else
                Destroy(turret.gameObject);
        }                
    }

    private void Handle_EventOnUpGrade(int index)
    {
        switch(index)
        {
            case 0: //upgrade
                if (turret.level_upgrade < 3)
                {              
                    if (HelperCalculate._instance.GetCoin() >= turret.cost_upgrade)
                    {
                        turret.attack = Calculation.AttackUpgrade(turret.attack);
                        turret.level_upgrade++;
                        Debug.Log(turret.attack);
                        turret.SetSprite();
                        HelperCalculate._instance.AddCoin(-turret.cost_upgrade);
                    }
                }
                else
                    Debug.Log("max level");
                break;
            case 1: // sell
                HelperCalculate._instance.AddCoin(Calculation.ReturnCoinSold(turret.total_cost_bouhgt));
                Destroy(turret.gameObject);

                _isbuild = false;
                SetActive(_isbuild);
                turret.Event_OnClickTurret -= Handle_EventOnclicTurret;
                break;
        }
       
    }

    public void OnStopGame()
    {
        if (turret != null)
        Destroy(turret.gameObject);
        Debug.Log("destroy");
    }

    private void Handle_Event_TouchObject(int id)
    {
            if (id != gameObject.GetInstanceID())
            {
                if (_isActive)
                {
                    Switch();
                }
                return;
            }
            Switch();     
        if(_isbuild)
        {
            Switch();
        }
    }

    private void Handle_Event_TouchBackGround()
    {
        if(_isActive)
        {
            Switch();
        }
    }

    private void SetActive(bool b)
    {
        spr1.SetActive(!b);
        spr2.SetActive(!b);
        _buildcanvas.gameObject.SetActive(false);
    }

    private void Switch()
    {
        _isActive = !_buildcanvas.gameObject.activeSelf;
        _buildcanvas.gameObject.SetActive(_isActive);
    }

    public void Spaw(int _itemIndex)
    {
        turret = Instantiate(list_turretPrefab[_itemIndex], transform.position, Quaternion.identity);
         TurretData data = list_turretDatas[_itemIndex];
        turret.name = data.name;
        turret.attack = data.attack;
        turret.range = data.range;
        turret.firRate = data.fireRate;
        turret.cost = data.cost;
        turret.cost_upgrade = data.cost_upgrade;
        turret.level_upgrade = data.level;
        turret.sprite1 = data.sprite1;
        turret.sprite2 = data.sprite2;
        turret.sprite3 = data.sprite3;
    }

    private void Handle_EventOnclicTurret()
    {
        canvasUpgrade.turret = turret;
        canvasUpgrade.SetTextCostUpgrade();
        canvasUpgrade.gameObject.SetActive(!canvasUpgrade.gameObject.activeSelf);
        _buildcanvas.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        shopTurret.Event_OnSelectItem -= Handle_EvenOnSelectItem;
        canvasUpgrade.Event_OnClickCanvasUpgrade -= Handle_EventOnUpGrade;

        TouchController.Event_TouchObject -= Handle_Event_TouchObject;
        TouchController.Event_TouchBackGround -= Handle_Event_TouchBackGround;
    }

}
