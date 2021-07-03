using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class TouchController : MonoBehaviour
{
    public static event Action Event_TouchUI;
    public static event Action Event_TouchBackGround;
    public static event Action<int> Event_TouchObject;

    [SerializeField] private LayerMask _layerHitMark;
    [SerializeField] private int _layerUI;
    [SerializeField] private int _turret;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
    }

    void Update()
    {
        var origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dir = Vector2.zero;

        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                if(EventSystem.current.currentSelectedGameObject.layer == _layerUI)
                {
                    Debug.Log("touch ui");
                    Event_TouchUI?.Invoke();
                    return;
                }
                else if(EventSystem.current.currentSelectedGameObject.layer == _turret)
                {
                    Debug.Log("touch turret");
                    return;
                }
            }

            RaycastHit2D hit = Physics2D.Raycast(origin, dir, float.PositiveInfinity, _layerHitMark);

            if (hit.collider != null)
            {
                Debug.Log($"Hit {hit.collider.name}");
                if (hit.collider.CompareTag("Place"))
                {
                    Event_TouchObject?.Invoke(hit.collider.gameObject.GetInstanceID());                 
                }
                else if (hit.collider.CompareTag("BackGround"))
                {
                    Event_TouchBackGround?.Invoke();
                }
            }
        }
        transform.position = origin;
    }
}
