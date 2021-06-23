using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasUpgrade : MonoBehaviour
{
    public Transform panel;
    public Turret turret;
    private Button button;
   
    void Start()
    {
        SetButtonUpdate();
    }


    private void OnClickedUpdrade (int index)
    {
        switch(index)
        {
            case 0:               
                turret.attack += 10;
                Debug.Log("up atk: " + turret.attack);
                turret.level_upgrade++;
                turret.SetSprite();
                HelperCalculate._instance.GetCoin((int)turret.cost_upgrade);
                
                break;
            case 1:
                Debug.Log("up range: " + turret.range);
                turret.range += 1;
                HelperCalculate._instance.GetCoin((int)turret.cost_upgrade);
                break;
        }
        gameObject.SetActive(false);
    }

    private void SetButtonUpdate()
    {
        for(int i = 0; i < panel.childCount; i++)
        {
            button = panel.GetChild(i).GetComponent<Button>();
            button.AddEventListener(i, OnClickedUpdrade);
        }
    }
}
