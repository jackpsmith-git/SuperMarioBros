using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    private int coinCount;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        coinCount = gameManager.coins;
    }

   private void Update()
   {
    coinCount = gameManager.coins;
    GetComponent<TMP_Text>().text = "x" + coinCount.ToString();
   } 
}
