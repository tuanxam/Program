using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUp : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public float speed;

    void Update()
    {
        transform.position += new Vector3(0, speed) * Time.deltaTime;
    }

    public void SetText(int i)
    {
        tmp.SetText(i.ToString());
        Destroy(gameObject, 1);
    }
}
