using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool moveUp, moveDown, moveLeft, moveRight;
    [SerializeField] float moveSpeed;

    [SerializeField] Vector2 direction;

    public bool dead;


    // Start is called before the first frame update
    void Start()
    {
        dead = false;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        //Aim();
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            Move();

        }

        if (dead)
        {
            rb.velocity = Vector2.zero;
        }

    }

    void Move()
    {
        if (moveLeft)
        {
            rb.AddForce(Vector2.left * moveSpeed * Time.fixedDeltaTime);

        }
        else if (moveRight)
        {
            rb.AddForce(Vector2.right * moveSpeed * Time.fixedDeltaTime);

        }

        if (moveUp)
        {
            rb.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);

        }
        else if (moveDown)
        {
            rb.AddForce(Vector2.down * moveSpeed * Time.fixedDeltaTime);

        }
        rb.velocity = Vector2.zero;
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDown = true;
        }
        else
        {
            moveDown = false;
        }

    }

    void Aim()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
    }

}
