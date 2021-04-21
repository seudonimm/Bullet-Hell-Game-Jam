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
    [SerializeField] float xVel;
    [SerializeField] float yVel;

    // Start is called before the first frame update
    void Start()
    {
        //spr.color = new Color(Random.Range(0.8f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //so far we only get sliding squares if the velocity of one of the x and y values is less than 0.1
         if(rb.velocity.y < 0.1f && rb.velocity.y >= 0 && count > 0 )// if the y velocity is between 0.1 and 0
        {
            rb.velocity = new Vector2(rb.velocity.x,Random.Range(-1f, 1f)) * moveSpeed * Time.deltaTime; // changes the y velocity to something random
        }
        
        if (rb.velocity.y > -0.1f && rb.velocity.y <= 0 && count > 0)// if the y velocity is between -0.1 and 0
        {
            rb.velocity = new Vector2(rb.velocity.x, Random.Range(-1f, 1f)) * moveSpeed * Time.deltaTime; // changes the y velocity to something random
        }

        if (rb.velocity.x < 0.1f && rb.velocity.x >= 0 && count > 0)// if the x velocity is between 0.1 and 0
        {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), rb.velocity.y) * moveSpeed * Time.deltaTime; // changes the x velocity to something random
        }
        
        if (rb.velocity.x > -0.1f && rb.velocity.x <= 0 && count > 0)// if the x velocity is between -0.1 and 0
        {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), rb.velocity.y) * moveSpeed * Time.deltaTime; // changes the x velocity to something random
        }
        rb.velocity = rb.velocity.normalized * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if ((col.gameObject.CompareTag("Destroy Box") && count == maxBounces) || col.gameObject.CompareTag("Destroyer"))
        {
            gameObject.SetActive(false);
            count = 0;
        }
        else
        {
            count++;
        }

    }
}
