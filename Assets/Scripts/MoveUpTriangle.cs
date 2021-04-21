using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpTriangle : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        //spr.color = new Color(Random.Range(0.8f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Destroy Box") || col.gameObject.CompareTag("Destroyer"))
        {
            gameObject.SetActive(false);

        }

    }
    //private void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("Destroy Box") || col.gameObject.CompareTag("Destroyer"))
    //    {
    //        gameObject.SetActive(false);
    //    }

    //}

}
