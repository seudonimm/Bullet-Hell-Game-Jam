using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEnemyStats
{
    private static float playerAccuracy;    //0
    private static float playerMoveSpeed;   //1
    private static float playerAtkDmg;      //2
    private static float playerRateOfFire;  //3
    private static float playerShotCount;   //4

    private static float enemySpawnRate;        //0
    private static float enemyAtkSpeed;         //1
    private static float enemyEliteSpawnRate;   //2

    public static float PlayerAccuracy { get => playerAccuracy; set => playerAccuracy = value; }    
    public static float PlayerMoveSpeed { get => playerMoveSpeed; set => playerMoveSpeed = value; }
    public static float PlayerAtkDmg { get => playerAtkDmg; set => playerAtkDmg = value; }
    public static float PlayerRateOfFire { get => playerRateOfFire; set => playerRateOfFire = value; }
    public static float PlayerShotCount { get => playerShotCount; set => playerShotCount = value; }

    public static float EnemySpawnRate { get => enemySpawnRate; set => enemySpawnRate = value; }
    public static float EnemyAtkSpeed { get => enemyAtkSpeed; set => enemyAtkSpeed = value; }
    public static float EnemyEliteSpawnRate { get => enemyEliteSpawnRate; set => enemyEliteSpawnRate = value; }
}
