using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;
    PlayerController controller;
    public int collectedObjects = 0;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }
    }
    // Start a new game
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }
    // Methid for the game over
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            //MenuManager.sharedInstance.HidePlayMenu();
            MenuManager.sharedInstance.HideGameOverMenu();
            MenuManager.sharedInstance.ShowMainMenu();
        } else if(newGameState == GameState.inGame)
        {
            MenuManager.sharedInstance.ShowPlayMenu();
            LevelManager.sharedInstance.RemoveAllLevelBlocks();
            LevelManager.sharedInstance.GenerateInitialBlocks();
            controller.StartGame();
            MenuManager.sharedInstance.HideMainMenu();
            MenuManager.sharedInstance.HideGameOverMenu();
        }
        else if(newGameState == GameState.gameOver)
        {
            MenuManager.sharedInstance.HidePlayMenu();
            MenuManager.sharedInstance.HideMainMenu();
            MenuManager.sharedInstance.ShowGameOverMenu();
        }
        this.currentGameState = newGameState;
    }
    public void CollectObject(Collectable collectable)
    {
        collectedObjects += collectable.value;
    }
}
