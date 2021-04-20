using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int enemyHealth;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player Projectile"))
        {
            enemyHealth--;

            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    //IEnumerator void DeathAnimation
}
