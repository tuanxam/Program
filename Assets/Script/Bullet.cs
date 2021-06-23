using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float attack;
    public DebuffBurn dbPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CreateDebuff(GameObject target)
    {
        DebuffBurn db = Instantiate(dbPrefab, target.transform.position, Quaternion.identity);
        db.damage = attack;
        db.ApplyDebuffToTarget(target);        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }  


}
