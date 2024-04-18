using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    public Transform playerPaddle;
    public Transform player2Paddle;
    
    public BallController ballController;

    public int playerScore = 0;
    public int player2Score = 0;

    public TextMeshProUGUI textPlayerPoints;
    public TextMeshProUGUI textPlayer2Points;

    public int winPoints = 5;

    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;

    public TextMeshProUGUI textInputName;
    public TextMeshProUGUI textInputName2;
    #endregion

    #region METHODS 
    // Start Position
    void Start()
    {
        ResetGame();
        InputName();
    }

   

    private void Update()
    {
        //To restart the game, press "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
          ResetGame();
           
        }
    }

    public void InputName()
    {
        textInputName.text = SaveController.Instance.playerName;
        textInputName2.text = SaveController.Instance.player2Name;
    }
    public void ResetGame()
    {
        // Start Paddles Position
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        player2Paddle.position = new Vector3(7f, 0f, 0f);

        // Start Ball Position
        ballController.ResetBall();

        // Start Players Points
        playerScore = 0;
        player2Score = 0;

        textPlayerPoints.text = playerScore.ToString();
        textPlayer2Points.text = player2Score.ToString();

        screenEndGame.SetActive(false);
    }

    public void PlayerScore() 
    {
        playerScore++;
        textPlayerPoints.text = playerScore.ToString();
        CheckWin();
    }

    public void Player2Score() 
    {
        player2Score++;
        textPlayer2Points.text = player2Score.ToString();
        CheckWin();
    }

    public void CheckWin() 
    {
        if (player2Score >= winPoints || playerScore >= winPoints) 
        {
            EndGame();
           
        }

    }

  
    public void EndGame() 
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > player2Score);
        textEndGame.text =  winner+ " Wins";
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 3f);
    }

    
    public void LoadMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    #endregion
}