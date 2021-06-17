using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject gun;   
    public GameObject bulletPrefab;
    public new string name;
    public Sprite sprite;
    public float attack;
    public float cost;
    public float cost_upgrade;
    public float range;
    public float firRate;
    public float fore;
    
    [SerializeField]
    public LayerMask layerMask;
    private Collider2D _target;
    private float _nextimtofire = 0;
    private Vector2 _dir;
    private Rigidbody2D _rb;
    public int id;
    private List<GameObject> bulletPool = new List<GameObject>();

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        _target = Physics2D.OverlapCircle(transform.position, range, layerMask);
  
        if(_target!=null)
        {
            _dir = _target.transform.position - transform.position;
            //LockAtTarget();
            if(_nextimtofire < Time.time)
            {
                Shoot();
                _nextimtofire = Time.time + 1/firRate;             
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
        bul.SetActive(true);
        bul.transform.position = transform.position;
        bul.GetComponent<Rigidbody2D>().AddForce(_dir * fore);
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
    
}
