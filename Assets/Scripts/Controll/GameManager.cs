using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private int coins;
    private int     currentBlockLive;
    private string  gameSceneName = "Game";
    private string  menuSceneName = "MainMenu";
    private float   currentGameSpeed = 1.0f;

    public int CurrentBlockLive {
        get
        {
            return currentBlockLive;
        }
        set
        {
            currentBlockLive = value;
            if (currentBlockLive == 0)
                CompleteGame();
        }
    }

    private void Start()
    {
        MainManager.inst.UIManager.UpdateLives(lives);
    }

    // ------------ stats logic ------------
    public void AddCoin(int amount)
    {
        coins += amount;
        MainManager.inst.UIManager.UpdateScore(coins);
    }

    public void AddLives(int amount)
    {
        lives += amount;
        MainManager.inst.UIManager.UpdateLives(lives);
    }

    public void RemoveLive()
    {
        lives--;
        MainManager.inst.UIManager.UpdateLives(lives);
        Debug.Log("Lives: "+ lives);
        if (lives == 0)
            FailGame();
    }

    // ------------ game state logic ------------
    private void CompleteGame()
    {
        PauseGameLogic();
        MainManager.inst.UIManager.ShowEndPanel(true);
        MainManager.inst.UIManager.UpdateWarningText("COMPLETE GAME!");
    }

    public void MissBall()
    {
        MainManager.inst.PlayerController.ResetStage();
        RemoveLive();
    }

    public void FailGame()
    {
        PauseGameLogic();
        MainManager.inst.UIManager.ShowEndPanel(true);
        MainManager.inst.UIManager.UpdateWarningText("FAIL GAME!");
    }

    // ------------
    public void ChangeSpeed()
    {
        currentGameSpeed += 0.5f;
        if (currentGameSpeed == 2.5f)
            currentGameSpeed = 1.0f;
        Time.timeScale = currentGameSpeed;
        MainManager.inst.UIManager.UpdateSpeedText(currentGameSpeed);
    }


    public void RestartGame()
    {
        ResumeGameLogic();
        MainManager.inst.UIManager.ShowEndPanel(false);
        SceneManager.LoadScene(gameSceneName);
    }

    public void ReturnMainMenu()
    {
        ResumeGameLogic();
        MainManager.inst.UIManager.ShowEndPanel(false);
        SceneManager.LoadScene(menuSceneName);
    }

    // ------------
    public void PauseGameLogic()
    {
        MainManager.inst.UIManager.SetActiveSpeedButton(false);
        Time.timeScale = 0f;
    }

    public void ResumeGameLogic()
    {
        MainManager.inst.UIManager.SetActiveSpeedButton(true);
        Time.timeScale = 1f;
    }
}
