using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPulse : MonoBehaviour/*, IPointerEnterHandler*/
{
    [SerializeField] Button button;

    [SerializeField] float t, size, min, max;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //button.OnPointerEnter()
        
    }

    private void OnMouseOver()
    {
        size = Mathf.Lerp(min, max, t);
        t = Mathf.PingPong(Time.unscaledTime, 1);
        transform.localScale = new Vector3(size, size, size);

        print("pulse");

    }

    //public void Pulse()
    //{
    //    size = Mathf.Lerp(min, max, t);
    //    t = Mathf.PingPong(Time.unscaledTime, 1);
    //    transform.localScale = new Vector3(size, size, size);

    //}
}
