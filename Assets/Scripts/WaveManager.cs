using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WaveManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies; // 0 = triangle; 1 = circle; 2 = square; 3 = triangle elite; 4 = circle elite; 5 = square elite;

    [SerializeField] float timer = 10;
    [SerializeField] TextMeshProUGUI timerText, wavesText, scoreText, finalScoreText;

    [SerializeField] GameState gameState;

    [SerializeField] GameObject chooseMenu, loseMenu;
    [SerializeField] Button choice1, choice2, choice3;
    [SerializeField] List<TextMeshProUGUI> choiceButtons, enemyChoiceButtons;

    [SerializeField] bool choiceChosen;

    [SerializeField] float tier1, tier2, tier3, currentTier;
    [SerializeField] float score1, score2, score3, totalScore;

    [SerializeField] List<int> playerRands, enemyRands;

    [SerializeField] int waveNum = 1;

    [SerializeField] Transform spawnPoint;
    private void Awake()
    {
        chooseMenu.SetActive(false);
        choiceChosen = false;
        waveNum = 1;
        UIValues.Timer = timer;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = UIValues.Timer.ToString();

        GameStateMachine();

        scoreText.text = "Score: " + UIValues.Score.ToString();

        Lost();

        TierCalcualtor();
    }

    void Lost()
    {
        if(UIValues.PlayerLives <= 0)
        {
            Time.timeScale = 0;
            loseMenu.SetActive(true);

            finalScoreText.text = "Final Score: " + totalScore + UIValues.Score;

            if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Gameplay");
            }
        }
    }
    void TierCalcualtor()
    {
        if(UIValues.Score < score1)
        {
            currentTier = tier1;
        }
        else if(UIValues.Score < score2)
        {
            currentTier = tier2;
        }
        else
        {
            currentTier = tier3;
        }
    }

    void GameStateMachine()
    {
        switch (gameState)
        {
            case GameState.Playing:
                UIValues.Timer -= Time.deltaTime;

                if (UIValues.Timer <= 0)
                {
                    gameState = GameState.EndPlaying;
                    Time.timeScale = 0;
                }
                break;

            case GameState.EndPlaying:
                chooseMenu.SetActive(true);

                for (int i = 0; i < playerRands.Count; i++)
                {
                    playerRands[i] = Random.Range(0, 5);

                    if (playerRands[i] == 0)
                    {
                        choiceButtons[i].text = "Increase PLAYER ACCURACY by " + currentTier/10;

                    }
                    if (playerRands[i] == 1)
                    {
                        choiceButtons[i].text = "Increase PLAYER SPEED by " + currentTier/10;

                    }
                    if (playerRands[i] == 2)
                    {
                        choiceButtons[i].text = "Increase PLAYER ATTACK DAMAGE by " + currentTier;

                    }
                    if (playerRands[i] == 3)
                    {
                        choiceButtons[i].text = "Increase PLAYER RATE OF FIRE by " + currentTier/10;

                    }
                    if (playerRands[i] == 4)
                    {
                        choiceButtons[i].text = "Increase PLAYER SHOT COUNT";

                    }
                }

                for (int i = 0; i < enemyRands.Count; i++)
                {
                    enemyRands[i] = Random.Range(0, 4);

                    if (enemyRands[i] == 0)
                    {
                        enemyChoiceButtons[i].text = "Increase ENEMY SPAWN RATE";
                    }
                    if (enemyRands[i] == 1)
                    {
                        enemyChoiceButtons[i].text = "Increase ENEMY ATTACK SPEED by " + currentTier/10;

                    }
                    if (enemyRands[i] == 2)
                    {
                        enemyChoiceButtons[i].text = "Increase ELITE ENEMY SPAWN RATE by " + currentTier;

                    }
                    if (enemyRands[i] == 3)
                    {
                        enemyChoiceButtons[i].text = "Increase ENEMY HEALTH";

                    }


                }

                gameState = GameState.ChoiceMenu;

                if(gameState != GameState.EndPlaying)
                {
                    totalScore += UIValues.Score * waveNum;
                    UIValues.Score = 0;
                    waveNum++;
                }

                break;

            case GameState.ChoiceMenu:

                chooseMenu.SetActive(true);

                break;

            case GameState.BeforePlaying:
                for (int i = 0; i < waveNum; i++)
                {
                    spawnPoint.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
                    int rand = Random.Range(0, enemies.Count);
                    Instantiate(enemies[rand], spawnPoint.position, spawnPoint.rotation);
                }
                chooseMenu.SetActive(false);

                UIValues.Timer = 10;

                gameState = GameState.Playing;
                if (gameState != GameState.BeforePlaying)
                {
                    Time.timeScale = 1;

                    wavesText.text = waveNum.ToString();
                }
                break;
        }
    }

    public void Choice1()
    {
        if (playerRands[0] == 0)
        {
            PlayerEnemyStats.PlayerAccuracy -= (currentTier/10);
        }
        if (playerRands[0] == 1)
        {
            PlayerEnemyStats.PlayerMoveSpeed *= (currentTier/10 + 1);
        }
        if (playerRands[0] == 2)
        {
            PlayerEnemyStats.PlayerAtkDmg += (int)currentTier;
        }
        if (playerRands[0] == 3)
        {
            PlayerEnemyStats.PlayerRateOfFire -= (currentTier/10);
        }
        if (playerRands[0] == 4)
        {
            PlayerEnemyStats.PlayerShotCount++;
        }

        if (enemyRands[0] == 0)
        {
            PlayerEnemyStats.EnemySpawnRate++;
        }
        if (enemyRands[0] == 1)
        {
            PlayerEnemyStats.EnemyAtkSpeed /= currentTier/10;
        }
        if (enemyRands[0] == 2)
        {
            PlayerEnemyStats.EnemyEliteSpawnRate += currentTier;
        }
        if (enemyRands[0] == 3)
        {
            PlayerEnemyStats.EnemyHealth+= (int)currentTier;
        }

        gameState = GameState.BeforePlaying;
    }
    public void Choice2()
    {
        if (playerRands[1] == 0)
        {
            PlayerEnemyStats.PlayerAccuracy -= (currentTier / 10);
        }
        if (playerRands[1] == 1)
        {
            PlayerEnemyStats.PlayerMoveSpeed *= (currentTier / 10 + 1);
        }
        if (playerRands[1] == 2)
        {
            PlayerEnemyStats.PlayerAtkDmg += (int)currentTier;
        }
        if (playerRands[1] == 3)
        {
            PlayerEnemyStats.PlayerRateOfFire -= (currentTier / 10);
        }
        if (playerRands[1] == 4)
        {
            PlayerEnemyStats.PlayerShotCount++;
        }

        if (enemyRands[1] == 0)
        {
            PlayerEnemyStats.EnemySpawnRate++;
        }
        if (enemyRands[1] == 1)
        {
            PlayerEnemyStats.EnemyAtkSpeed -= currentTier;
        }
        if (enemyRands[1] == 2)
        {
            PlayerEnemyStats.EnemyEliteSpawnRate += currentTier;
        }
        if (enemyRands[1] == 3)
        {
            PlayerEnemyStats.EnemyHealth += (int)currentTier;
        }

        gameState = GameState.BeforePlaying;


    }
    public void Choice3()
    {
        if (playerRands[2] == 0)
        {
            PlayerEnemyStats.PlayerAccuracy -= (currentTier / 10);
        }
        if (playerRands[2] == 1)
        {
            PlayerEnemyStats.PlayerMoveSpeed *= (currentTier / 10 + 1);
        }
        if (playerRands[2] == 2)
        {
            PlayerEnemyStats.PlayerAtkDmg += (int)currentTier;
        }
        if (playerRands[2] == 3)
        {
            PlayerEnemyStats.PlayerRateOfFire -= (currentTier / 10);
        }
        if (playerRands[2] == 4)
        {
            PlayerEnemyStats.PlayerShotCount++;
        }

        if (enemyRands[2] == 0)
        {
            PlayerEnemyStats.EnemySpawnRate++;
        }
        if (enemyRands[2] == 1)
        {
            PlayerEnemyStats.EnemyAtkSpeed -= currentTier;
        }
        if (enemyRands[2] == 2)
        {
            PlayerEnemyStats.EnemyEliteSpawnRate += currentTier;
        }
        if (enemyRands[2] == 3)
        {
            PlayerEnemyStats.EnemyHealth += (int)currentTier;
        }

        gameState = GameState.BeforePlaying;


    }


}

public enum GameState
{
    Playing,
    EndPlaying,
    ChoiceMenu,
    BeforePlaying
}