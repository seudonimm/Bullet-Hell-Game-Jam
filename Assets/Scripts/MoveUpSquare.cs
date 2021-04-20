using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpSquare : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] int count;
    [SerializeField] int maxBounces;
    [SerializeField] LayerMask mask;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        spr.color = new Color(Random.Range(0.8f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
        rb.velocity = new Vector2(1,1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Destroy Box") && count == maxBounces)
        {
            gameObject.SetActive(false);
            count = 0;
        }
        else
        {/*
            transform.position += transform.up * moveSpeed * Time.deltaTime;
            Ray2D ray = new Ray2D(transform.position, transform.up);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, mask);
            Vector2 reflectDir = Vector2.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.x, reflectDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, rot);*/
            count++;
        }

    }
}
