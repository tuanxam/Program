using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnerTurret : MonoBehaviour
{
    public List<Turret> list_turretPrefab = new List<Turret>();
    public List<TurretData> list_turretDatas = new List<TurretData>();

    public void Spaw(int _itemIndex)
    {
        Instantiate(list_turretPrefab[_itemIndex], transform.position, Quaternion.identity);
        //g = GetComponent<Turret>();
        //g.name = list_turretDatas[_itemIndex].name;
        //g.attack = list_turretDatas[_itemIndex].attack;
        //g.range = list_turretDatas[_itemIndex].range;
        //g.firRate = list_turretDatas[_itemIndex].fireRate;
        //g.cost = list_turretDatas[_itemIndex].cost;
        //g.cost_upgrade = list_turretDatas[_itemIndex].cost_upgrade;
    }
}
