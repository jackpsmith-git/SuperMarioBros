using TMPro;
using UnityEngine;

public class CurrentScore : MonoBehaviour
{
    private int currentScore;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentScore = gameManager.score;
    }

   private void Update()
   {
    currentScore = gameManager.score;
    GetComponent<TMP_Text>().text = currentScore.ToString();
   } 
}
