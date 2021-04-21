using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool moveUp, moveDown, moveLeft, moveRight;
    [SerializeField] float moveSpeed;

    [SerializeField] Vector2 direction;

    [SerializeField] int lives;

    [SerializeField] TextMeshProUGUI livesText;

    [SerializeField] float invulnTimer, invulnTimerDefault;


    public bool dead;

    private void Awake()
    {
        PlayerEnemyStats.PlayerMoveSpeed = moveSpeed;
        livesText.text = "Lives: " + lives.ToString();
        UIValues.PlayerLives = lives;
    }
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

        moveSpeed = PlayerEnemyStats.PlayerMoveSpeed;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Circle Projectile") || col.gameObject.CompareTag("Triangle Projectile") || col.gameObject.CompareTag("Square Projectile"))
        {
            StartCoroutine("InvulnTime");
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            UIValues.PlayerLives = lives;

            if (lives <= 0)
            {
                dead = true;
            }
        }
    }

    IEnumerator InvulnTime()
    {

        Physics2D.IgnoreLayerCollision(9, 7, true);
        Physics2D.IgnoreLayerCollision(9, 6, true);

        yield return new WaitForSeconds(invulnTimer);

        Physics2D.IgnoreLayerCollision(9, 7, false);
        Physics2D.IgnoreLayerCollision(9, 6, false);

    }
}