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
    private void OnEnable()
    {
        ShopTurret.Event_OnClickBuy += Spaw;

    }
    private void OnDisable()
    {
        ShopTurret.Event_OnClickBuy -= Spaw;
    }

    public void Spaw(int _id)
    {
        switch(_id)
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
