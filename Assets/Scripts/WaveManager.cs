using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies; // 0 = circle; 1 = triangle; 2 = square; 3 = circle elite; 4 = triangle; 5 = square elite;

    [SerializeField] float timer = 10;
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] GameState gameState;

    [SerializeField] GameObject chooseMenu;
    [SerializeField] Button choice1, choice2, choice3;

    [SerializeField] bool choiceChosen;


    private void Awake()
    {
        chooseMenu.SetActive(false);
        choiceChosen = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString();

        GameStateMachine();
        
    }

    void GameStateMachine()
    {
        switch (gameState)
        {
            case GameState.Playing:
                timer -= Time.deltaTime;

                if(timer <= 0)
                {
                    gameState = GameState.EndPlaying;
                    Time.timeScale = 0;
                }
                break;

            case GameState.EndPlaying:


                gameState = GameState.ChoiceMenu;
                break;

            case GameState.ChoiceMenu:

                chooseMenu.SetActive(true);

                break;

            case GameState.BeforePlaying:
                chooseMenu.SetActive(false);

                gameState = GameState.Playing;
                if(gameState != GameState.BeforePlaying)
                {
                    Time.timeScale = 1;
                }
                break;
        }
    }

    public void Choice1()
    {

    }
    public void Choice2()
    {

    }
    public void Choice3()
    {

    }

}

public enum GameState
{
    Playing,
    EndPlaying,
    ChoiceMenu,
    BeforePlaying
}