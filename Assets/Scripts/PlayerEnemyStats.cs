using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEnemyStats
{
    private static float playerAccuracy;
    private static float playerMoveSpeed;
    private static float playerAtkDmg;
    private static float playerRateOfFire;
    private static float playerShotCount;

    private static float enemySpawnRate;
    private static float enemyAtkSpeed;
    private static float enemyEliteSpawnRate;

    public static float PlayerAccuracy { get => playerAccuracy; set => playerAccuracy = value; }
    public static float PlayerMoveSpeed { get => playerMoveSpeed; set => playerMoveSpeed = value; }
    public static float PlayerAtkDmg { get => playerAtkDmg; set => playerAtkDmg = value; }
    public static float PlayerRateOfFire { get => playerRateOfFire; set => playerRateOfFire = value; }
    public static float PlayerShotCount { get => playerShotCount; set => playerShotCount = value; }

    public static float EnemySpawnRate { get => enemySpawnRate; set => enemySpawnRate = value; }
    public static float EnemyAtkSpeed { get => enemyAtkSpeed; set => enemyAtkSpeed = value; }
    public static float EnemyEliteSpawnRate { get => enemyEliteSpawnRate; set => enemyEliteSpawnRate = value; }
}
