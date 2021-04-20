using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    [SerializeField] List<GameObject> enemies; // 0 = trangle; 1 = circle; 2 = square; 3 = triangle elite; 4 = cirle elite; 5 = square elite;

    [SerializeField] float triangleChance, circleChance, squareChance, eTriangleChance, eCircleChance, eSquareChance;

    [SerializeField] float spawnTimer, spawnTimerDefault;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer <= 0)
        {
            SpawnEnemy();
        }

        spawnTimer -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        spawnPoint.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));

        int rand = Random.Range(0, 100);

        if(rand < triangleChance)
        {
            Instantiate(enemies[0], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < circleChance)
        {
            Instantiate(enemies[1], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < squareChance)
        {
            Instantiate(enemies[2], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < eTriangleChance)
        {
            Instantiate(enemies[3], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < eCircleChance)
        {
            Instantiate(enemies[4], spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(enemies[5], spawnPoint.position, spawnPoint.rotation);

        }
        GameObject.fi
        var dir = (Vector2)target.transform.position - (Vector2)transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + adjustment;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        spawnTimer = spawnTimerDefault;
    }
}
