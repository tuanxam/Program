using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnerTurret : MonoBehaviour
{
    public List<Turret> turrets = new List<Turret>();
    void Start()
    {
    }

    public void Spaw(int _item)
    {
        switch(_item)
        {
            case 1:
                Instantiate(turrets[0], transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(turrets[1], transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(turrets[2], transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(turrets[3], transform.position, Quaternion.identity);
                break;
        }
        gameObject.SetActive(false);
    }
}
