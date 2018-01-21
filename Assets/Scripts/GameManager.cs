using UnityEngine;
using System.Collections;

public enum GameState{
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;

    // Use this for initialization
    void Start()
    {
        //StartGame();

    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            this.StartGame();

        }
    }

    public void StartGame ()
    {
        PlayerController.instance.StartGame();
        this.SetCurrentGameState(GameState.inGame);
    }

    public void GameOver()
    {
        this.SetCurrentGameState(GameState.gameOver);

    }

    public void BackToManu()
    {
        this.SetCurrentGameState(GameState.menu);

    }

    void SetCurrentGameState (GameState newGamestate)
    {
        if (newGamestate == GameState.menu)
        {

        } else if (newGamestate == GameState.inGame)
        {

        } else if (newGamestate == GameState.gameOver)
        {

        }

        currentGameState = newGamestate;
    }    
}
