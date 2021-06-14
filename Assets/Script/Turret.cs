using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject gun;
    public float range;
    public GameObject bullet;
    public float firRate;
    public float fore;
    
    [SerializeField]
    public LayerMask layerMask;
    private Collider2D _target;
    private float _nextimtofire = 0;
    private Vector2 _dir;
    private Rigidbody2D _rb;
    public int id;

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
            LockAtTarget();
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
        var bul = Instantiate(bullet, gun.transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().AddForce(_dir * fore);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
}
