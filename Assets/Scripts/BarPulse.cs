using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPulse : MonoBehaviour
{
    [SerializeField] float t, size, min, max;
    [SerializeField] GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (obj.transform.localScale.x >= .9f)
        {
            size = Mathf.Lerp(min, max, t);
            t = Mathf.PingPong(Time.time, 1);
            transform.localScale = new Vector3(size, 1.5f, 1);
        }
    }
}
