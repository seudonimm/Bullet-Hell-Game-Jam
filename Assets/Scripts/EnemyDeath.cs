using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int enemyHealth;
    [SerializeField] int playerDmg = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth += PlayerEnemyStats.EnemyHealth;

        PlayerEnemyStats.PlayerAtkDmg = playerDmg;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player Projectile"))
        {
            playerDmg = PlayerEnemyStats.PlayerAtkDmg;

            enemyHealth -= playerDmg;

            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }

            //scoring
            if(tag == "Elite Enemy")
            {
                UIValues.Score += 3;
            }
            else
            {
                UIValues.Score++;
            }
        }
    }

    //IEnumerator void DeathAnimation
}
