using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        timer = Mathf.RoundToInt(gameManager.timeRemaining);
    }

   private void Update()
   {
    timer = Mathf.RoundToInt(gameManager.timeRemaining);
    GetComponent<TMP_Text>().text = timer.ToString();
   } 
}