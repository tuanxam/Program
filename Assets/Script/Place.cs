using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Place : MonoBehaviour
{
    public Button bt_build;
    public GameObject shopTurret;
    void Start()
    {
        bt_build.onClick.AddListener(OnclickBuild);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnclickBuild()
    {
        shopTurret.transform.position = transform.position;
        shopTurret.SetActive(true);       
    }
}
