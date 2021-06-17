using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class TurretData : ScriptableObject
{
    public new string name;
    public float attack;
    public float fireRate;
    public Sprite sprite;
    public float range;
    public float cost;
    public float cost_upgrade;
}
