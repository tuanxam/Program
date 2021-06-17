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
        Turret g = Instantiate(list_turretPrefab[_itemIndex], transform.position, Quaternion.identity);
        TurretData data = list_turretDatas[_itemIndex];
        g.name = data.name;
        g.attack = data.attack;
        g.range = data.range;
        g.firRate = data.fireRate;
        g.cost = data.cost;
        g.cost_upgrade = data.cost_upgrade;
    }
}
