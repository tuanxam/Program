using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    public float speed;
    public int enemyCoin;
    public float hp;
    public float current_hp;
    public float def;
    public PopUp popupPrefab;
    public WayPoint _wayPoint;
    private int _waypointIndex;

    void Start()
    {     
        current_hp = hp;
    }

  
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoint.waypoints[_waypointIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,_wayPoint.waypoints[_waypointIndex].position) < 0.1f)
        {
            if (_waypointIndex < _wayPoint.waypoints.LongLength - 1)
            {
                _waypointIndex++;
            }
            else
            {
                gameObject.SetActive(false);
                GameManager._instance.current_life--;
                _waypointIndex = 0;
            }
        }
    }

    void Handle_Event_isDefeat(bool status)
    {
        if(status)
        {
            gameObject.SetActive(false);
            _waypointIndex = 0;
        }
    }

    void Handle_Event_isWin(bool status)
    {
        if (status)
        {
            gameObject.SetActive(false);
            _waypointIndex = 0;
        }
    }

    private void OnEnable()
    {
        GameManager._instance.Event_IsDefeat += Handle_Event_isDefeat;
        GameManager._instance.Event_IsWin += Handle_Event_isWin;
    }

    private void OnDisable()
    {
        GameManager._instance.Event_IsWin -= Handle_Event_isWin;
        GameManager._instance.Event_IsDefeat -= Handle_Event_isDefeat;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
           

            current_hp -= Calculation.DamgeTaken(collision.gameObject.GetComponent<Bullet>().attack, def);

            collision.gameObject.GetComponent<Bullet>().CreateDebuff(gameObject);
            
            PopUp p =  Instantiate(popupPrefab, transform.position, Quaternion.identity);
            p.transform.position = transform.position;
            p.SetText((int)Calculation.DamgeTaken(collision.gameObject.GetComponent<Bullet>().attack, def));
            
            if(current_hp < 1)
            {
                gameObject.SetActive(false);
                HelperCalculate._instance.AddCoin(enemyCoin);
                _waypointIndex = 0;
            }         
            
        }
    }

}
