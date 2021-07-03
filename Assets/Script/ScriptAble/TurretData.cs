using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class TurretData : ScriptableObject
{
    public new string name;
    public float attack;
    public float fireRate;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public float range;
    public int cost;
    public int cost_upgrade;
    public int level;
}
