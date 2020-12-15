using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerGameOver : MonoBehaviour
{
    string player1N;
    string player2N;
    private void Awake()
    {
        player1N = PlayerPrefs.GetString("player1Name");
        player2N = PlayerPrefs.GetString("player2Name");
    }

    public Text Player1Score;
    public Text Player2Score;
    public Text whoWon;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("player1Score") > PlayerPrefs.GetInt("player2Score"))
        {
            Player1Score.text = player1N + " Scored : " + PlayerPrefs.GetInt("player1Score");
            Player2Score.text = player2N + " Scored : " + PlayerPrefs.GetInt("player2Score");
            whoWon.text = "Congrats! " + player1N + " you Won";
        }
        else if (PlayerPrefs.GetInt("player1Score") < PlayerPrefs.GetInt("player2Score"))
        {
            Player1Score.text = player1N + " Scored : " + PlayerPrefs.GetInt("player1Score");
            Player2Score.text = player2N + " Scored : " + PlayerPrefs.GetInt("player2Score");
            whoWon.text = "Congrats! " + player2N + " you Won";
        }
        else
        {
            Player1Score.text = player1N + " Scored : " + PlayerPrefs.GetInt("player1Score");
            Player2Score.text = player2N + " Scored : " + PlayerPrefs.GetInt("player2Score");
            whoWon.text = "Its a Draw!";
        }

    }


}