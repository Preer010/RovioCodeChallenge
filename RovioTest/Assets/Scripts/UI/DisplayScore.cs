using ModestTree;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DisplayScore : MonoBehaviour
{

    [SerializeField]
    Text currentScore;

    [Inject] GameManager gameManager;

    string currentScoreString = "Current Score: ";
    string highScoreString = "High Score: ";

    private void Start()
    {
        Assert.IsNotEqual(currentScore, null);
    }

    void Update()
    {
        // TODO(marcus dahl 07/03/2024): make this listen to the scoremanager and only update when necessary 
        string newText = currentScoreString + gameManager.scoreManager.currentScore + "\n" + highScoreString + gameManager.scoreManager.highScore;
        currentScore.text = newText;
    }
}
