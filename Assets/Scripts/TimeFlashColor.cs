using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeFlashColor : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] float t;

    [SerializeField] 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UIValues.Timer <= 3)
        {
            t = Mathf.PingPong(Time.time, 1);
            //time.color
        }
    }
}
