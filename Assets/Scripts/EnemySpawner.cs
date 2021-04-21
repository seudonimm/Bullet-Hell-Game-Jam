using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    [SerializeField] List<GameObject> enemies; // 0 = trangle; 1 = circle; 2 = square; 3 = triangle elite; 4 = cirle elite; 5 = square elite;

    [SerializeField] float triangleChance, circleChance, squareChance, eTriangleChance, eCircleChance, eSquareChance;

    [SerializeField] float spawnTimer, spawnTimerDefault;

    [SerializeField] float spawnIncreases = 1;
    [SerializeField] float spawnIncreaseTimer, spawnIncreaseTimerDefault = 6;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerEnemyStats.EnemySpawnRate = spawnIncreases;
        spawnIncreaseTimer = spawnIncreaseTimerDefault;

        triangleChance -= PlayerEnemyStats.EnemyEliteSpawnRate;
        circleChance -= PlayerEnemyStats.EnemyEliteSpawnRate;
        squareChance -= PlayerEnemyStats.EnemyEliteSpawnRate;
        eTriangleChance += PlayerEnemyStats.EnemyEliteSpawnRate;
        eCircleChance += PlayerEnemyStats.EnemyEliteSpawnRate;
        eSquareChance += PlayerEnemyStats.EnemyEliteSpawnRate;

    }

    // Update is called once per frame
    void Update()
    {
        if(spawnIncreaseTimer <= 0)
        {
            PlayerEnemyStats.EnemySpawnRate++;
            spawnIncreases = PlayerEnemyStats.EnemySpawnRate;
            spawnIncreaseTimer = spawnIncreaseTimerDefault;

        }
        if (spawnTimer <= 0)
        {
            for (int i = 0; i <= spawnIncreases; i++)
            {
                SpawnEnemy();
            }
            spawnTimer = spawnTimerDefault;

        }
        spawnIncreaseTimer -= Time.deltaTime;
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
        else if(rand < triangleChance + circleChance)
        {
            Instantiate(enemies[1], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < circleChance + squareChance)
        {
            Instantiate(enemies[2], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < squareChance + eTriangleChance)
        {
            Instantiate(enemies[3], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < eTriangleChance + eCircleChance)
        {
            Instantiate(enemies[4], spawnPoint.position, spawnPoint.rotation);
        }
        else if(rand < eCircleChance + eSquareChance)
        {
            Instantiate(enemies[5], spawnPoint.position, spawnPoint.rotation);

        }


        spawnTimer = spawnTimerDefault;
    }
}
