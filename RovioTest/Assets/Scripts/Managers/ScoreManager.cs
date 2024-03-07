using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    int newPlayerAmount = 100;
 
    public int currentScore = 0;
    public int highScore = 0;

    [Inject] GameManager gameManager;

    public void AddScore(int score)
    {
        int oldValue = currentScore / newPlayerAmount;

        currentScore += score;

        if (oldValue != currentScore / newPlayerAmount)
        {
            gameManager.SpawnPlayer();
        }
    }
    public void EndGame()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }

        currentScore = 0;
    }
}
