using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject gun;   
    public GameObject bulletPrefab;
    public new string name;
    
    public float attack;
    public float cost;
    public float cost_upgrade;
    public float range;
    public float firRate;
    public float fore;
    public int id;
    
    [SerializeField] private Canvas _canvasUpgrade;
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
        level_upgrade = 1;
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
    }

    private void CheckTarget()
    {
        _target = Physics2D.OverlapCircle(transform.position,range,layerMask);
        
        if (_target!=null)
        {
            _distance = (_target.transform.position - transform.position).magnitude;

            if ( _distance <= range)
            {
                _dir = _target.transform.position - transform.position;
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
        bul.GetComponent<Bullet>().attack = attack;
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

    private void OnMouseDown()
    {
        _canvasUpgrade.gameObject.SetActive(!_canvasUpgrade.gameObject.activeSelf);
    }

}
