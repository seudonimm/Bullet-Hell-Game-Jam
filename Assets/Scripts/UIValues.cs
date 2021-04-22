using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIValues
{
    private static int playerLives;
    private static int score;
    private static float meter;
    private static float shakeDuration;

    public static int PlayerLives { get => playerLives; set => playerLives = value; }
    public static int Score { get => score; set => score = value; }
    public static float Meter { get => meter; set => meter = value; }
    public static float ShakeDuration { get => shakeDuration; set => shakeDuration = value; }
}
