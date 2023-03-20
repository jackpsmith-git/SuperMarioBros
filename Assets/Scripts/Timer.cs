using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;
    private GameManager gameManager;
    private GameObject mario;
    public AudioManager audioManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        mario =  GameObject.FindWithTag("Player");
        audioManager = mario.GetComponentInChildren<AudioManager>();
        timer = Mathf.RoundToInt(gameManager.timeRemaining);
    }

   private void Update()
   {
    timer = Mathf.RoundToInt(gameManager.timeRemaining);
    GetComponent<TMP_Text>().text = timer.ToString();
    if (timer == 100 && !audioManager.hurryUp.isPlaying)
    {
        audioManager.hurryUp.Play();
    }
   } 
}