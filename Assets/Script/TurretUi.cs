using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUi : MonoBehaviour
{
    public Turret turretPrefab;
    void Start()
    {
        
    }
 
    void Update()
    {
        
    }

    public void Onlick()
    {
        var turret = Instantiate(turretPrefab);
        turret.SetPositon();
    }
}
