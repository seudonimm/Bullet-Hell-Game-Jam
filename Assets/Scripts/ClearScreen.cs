using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CircleCollider2D circleCol;

    [SerializeField] bool grow;
    [SerializeField] float growSpeed;

    //[SerializeField] Transform circleEffect;

    [SerializeField] float meterVal, meterValMax, t;
    [SerializeField] GameObject meterRect;

    [SerializeField] float x;

    // Start is called before the first frame update
    void Start()
    {
        grow = false;
        //circleCol.radius = 0;
        //circleEffect.localScale = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        meterVal = UIValues.Meter;
        t = UIValues.Meter / meterValMax;
        meterRect.transform.localScale = new Vector2(Mathf.Lerp(0, 1, t), meterRect.transform.localScale.y);

        if (Input.GetKey(KeyCode.Space) && UIValues.Meter >= meterValMax)
        {
            grow = true;
            UIValues.Timer = 10;

        }

        if (grow)
        {
            //circleCol.radius += growSpeed * Time.deltaTime;
            //circleEffect.localScale = new Vector2(circleCol.radius * circleCol.radius, circleCol.radius * circleCol.radius);
            transform.localScale += Vector3.one * Time.deltaTime * growSpeed;
            if (transform.localScale.x >= 70)
            {
                grow = false;
                //circleCol.radius = 0;
                UIValues.Meter = 0;
                transform.localScale = Vector2.zero;

            }
        }
    }
}
