using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Enemy enemy;
    public GameObject gun;
    public float range;
    public GameObject bullet;
    public float firRate;
    public float fore;
    
    private float nextimtofire = 0;
    private Vector2 _dir;
    private bool isDetected;
    private bool isSelected;
    private bool isBuild;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected)
        {
            SetPositon();
        }

        Vector2 targetpos = enemy.transform.position;
        _dir = targetpos - (Vector2)transform.position;

        RaycastHit2D raycast = Physics2D.Raycast(transform.position, _dir, range);

        if (raycast)
        {
            if (raycast.collider.CompareTag("Enemy"))
            {
                isDetected = true;
                Debug.Log("eneemy");
            }
            else
            {
                if (isDetected)
                {
                    isDetected = false;
                }
            }
        }

        if (isDetected)
        {
            gun.transform.up = _dir;
            if (Time.time > nextimtofire)
            {
                nextimtofire = Time.time + 1 / firRate;
                Shoot();
            }
        }
    }

    public void SetPositon()
    {
        isSelected = true;
        Vector2 currenpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(currenpos.x, currenpos.y);
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

    private void OnMouseDown()
    {
        if (isBuild)
        {
            isSelected = false;
        }          
        else
        {
            isSelected = true;
        }
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Plane"))
        {
            Debug.Log("hitt");
            if(Input.GetMouseButtonUp(0))
            {
                isSelected = false;
                isBuild = true;
            }            
        }
    }
  
}
