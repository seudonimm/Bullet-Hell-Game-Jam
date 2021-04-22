using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionSpace : MonoBehaviour
{
    [SerializeField] float currTimeScaleVal, slowMoVal, t, slowSpeed, tSlow;
    [SerializeField] bool slowDown;

    [SerializeField] Color indicator;

    // Start is called before the first frame update
    void Start()
    {
        t = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIValues.Timer >= 0)
        {
            currTimeScaleVal = Time.timeScale;
            Time.timeScale = Mathf.Lerp(slowMoVal, 1, t);

            if (slowDown)
            {
                t -= Time.deltaTime * slowSpeed;
                tSlow -= Time.deltaTime;
            }
            if (!slowDown)
            {
                t += Time.deltaTime * slowSpeed;
                tSlow += Time.deltaTime;

            }
            t = Mathf.Clamp(t, slowMoVal, 1);
            tSlow = Mathf.Clamp(t, 0, 5);
            if (Time.timeScale == slowMoVal)
            {
            }
            else
            {
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Triangle Projectile") || col.gameObject.CompareTag("Circle Projectile") || col.gameObject.CompareTag("Square Projectile"))
        {
            slowDown = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Triangle Projectile") || col.gameObject.CompareTag("Circle Projectile") || col.gameObject.CompareTag("Square Projectile"))
        {
            slowDown = true;
            //Time.timeScale = Mathf.Lerp() 
                //slowMoVal;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Triangle Projectile") || col.gameObject.CompareTag("Circle Projectile") || col.gameObject.CompareTag("Square Projectile"))
        {
            slowDown = false;
            //Time.timeScale = 1f;
        }
    }
}
