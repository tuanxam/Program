using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public float hp;
    public float move_speed;
    public int coin;
    [Range(0,100)]
    public float def;
}

