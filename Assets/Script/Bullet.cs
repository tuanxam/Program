using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float attack;
    [HideInInspector] public Rigidbody2D rb;
    public DebuffBurn dbPrefab;
    public GameObject explosionRefab;
    public bool isDebuffActive;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void CreateDebuff(GameObject target)
    {
        if(target.GetComponent<Enemy>().isdebuff != true)
        {
            if (dbPrefab != null)
            {
                DebuffController db = Instantiate(dbPrefab, target.transform.position, Quaternion.identity);
                db.damage = attack;
                db.ApplyDebuffToTarget(target);
            }
        }
    }

    private void CreatExplosion()
    {
        if(explosionRefab !=null)
        Instantiate(explosionRefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {           
            gameObject.SetActive(false);
            CreatExplosion();

        }
        if(collision.CompareTag("Enemy"))
        {
            CreateDebuff(collision.gameObject);
            CreatExplosion();
            gameObject.SetActive(false);
        }      
    }  


}
