using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffBurn : DebuffController
{
    public float damagePercent;
    public float duration;
    public float delayDebuff;
    public string typeDebuff;
    public PopUp popupPrefab;

    protected override void ApplyDebuff(GameObject target)
    {             
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.isdebuff = true;
        float current_targethp = enemy.current_hp;
        float damage_per_second = (damagePercent * damage) / 100;
        current_targethp -= damage_per_second;
        enemy.current_hp = current_targethp;
        PopUp p = Instantiate(popupPrefab, target.transform.transform.position, Quaternion.identity);
        p.SetText((int)damage_per_second);
    }
       
    protected override float Delay()
    {
        return delayDebuff;
    }

    protected override float Duration()
    {
        return duration;
    }

    protected override void RemoveDebuff(GameObject target)
    {
        Destroy(gameObject);
    }

    protected override string TypeDebuff()
    {
        return typeDebuff;
       
    }
}

    