using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Turret : MonoBehaviour
{
    public event Action Event_OnClickTurret;
    public GameObject gun;   
    public GameObject bulletPrefab;
    public new string name;
    public float offset;
    public float attack;
    public int cost;
    public int cost_upgrade;
    public float range;
    public float firRate;
    public float fore;
    public int id;
    public int total_cost_bouhgt;
    [SerializeField] private LayerMask layerMask;
    [HideInInspector] public int level_upgrade;
    [HideInInspector] public Sprite sprite1, sprite2, sprite3;

    private SpriteRenderer _spr;
    private Collider2D _target;
    private float _nextimtofire = 0;
    private Vector2 _dir;
    private Rigidbody2D _rb;
    private float _distance = Mathf.Infinity;
    private List<GameObject> bulletPool = new List<GameObject>();

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
    }

    public void SetSprite()
    {
       switch(level_upgrade)
        {
            case 1:
                _spr.sprite = sprite1;
                break;
            case 2:
                _spr.sprite = sprite2;
                break;
            case 3:
                _spr.sprite = sprite3;
                break;
        }
        total_cost_bouhgt = Calculation.TotalCostBought(cost, cost_upgrade, level_upgrade);     
    }



    private void CheckTarget()
    {
        _target = Physics2D.OverlapCircle(transform.position,range,layerMask);
        
        if (_target!=null)
        {
            _distance = (_target.transform.position - transform.position).magnitude;

            if ( _distance <= range)
            {
                _dir = _target.transform.position - gun.transform.position;
                //LockAtTarget();
                if (_nextimtofire < Time.time)
                {
                    Shoot();
                    _nextimtofire = Time.time + 1 / firRate;
                }
            }
        }
    }

    private void LockAtTarget()
    {
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90;
        _rb.rotation = angle;
    }

    private void Shoot()     
    {
        var bul = GetBulletFromPool();
        float z = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        bul.GetComponent<Bullet>().attack = attack;
        bul.SetActive(true);

        bul.transform.position = gun.transform.position;       
        gun.transform.rotation = Quaternion.Euler(0, 0, z + offset);
        bul.transform.rotation = gun.transform.rotation;  
        
        bul.GetComponent<Rigidbody2D>().velocity = _dir * 3;   /*AddForce(_dir * fore);*/
    }

    GameObject GetBulletFromPool()
    {
        foreach(GameObject g in bulletPool)
        {
            if (g.activeSelf == false)
                return g;
        }
        var new_bullet = Instantiate(bulletPrefab);
        bulletPool.Add(new_bullet);
        return new_bullet;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnMouseDown()
    {
        Event_OnClickTurret?.Invoke();
    }
}

