using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnerTurret : MonoBehaviour
{
    public List<Turret> turrets = new List<Turret>();
    private Place place;
    void Start()
    {
        place = GetComponent<Place>();
    }
    private void OnEnable()
    {
        Place.Event_OnClickPlace += CheckId;       
    }
    private void OnDisable()
    {
        ShopTurret.Event_OnClickBuy -= Spaw;
    }

    private void CheckId(int id)
    {
        if(id == place.id)
        {
            ShopTurret.Event_OnClickBuy += Spaw;
        }
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
