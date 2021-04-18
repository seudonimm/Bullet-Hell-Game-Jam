using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIValues
{
    private static int playerLives;
    private static int score;

    public static int PlayerLives { get => playerLives; set => playerLives = value; }
    public static int Score { get => score; set => score = value; }
}
