using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr.color = new Color(Random.Range(0.8f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Destroy Box"))
        {
            gameObject.SetActive(false);
        }
    }

}
