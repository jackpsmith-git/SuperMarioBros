using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int coins { get; private set; }
    public int score;
    public float timeRemaining;
    public bool timeActive;
    private GameObject mario;
    public AudioManager audioManager;

    private void Awake()
    {
        mario =  GameObject.FindWithTag("Player");
        audioManager = mario.GetComponentInChildren<AudioManager>();

        timeRemaining = 400;
        timeActive = true;
        
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        NewGame();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            if (timeActive == true)
            {
                timeRemaining -= Time.deltaTime;
            }
            
        }
        else
        {
            if (timeActive == true)
            {
                NewGame();
            }
        }
    }

    private void NewGame()
    {
        lives = 3;
        coins = 0;
        score = 0;
        timeRemaining = 400;

        LoadLevel(1, 1);
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;
        timeRemaining = 400;
        timeActive = true;
        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        LoadLevel(world, stage + 1);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0)
        {
            LoadLevel(world, stage);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        audioManager.gameOver.Play();
        NewGame();
    }

    public void AddCoin()
    {
        coins++;
        score = score + 200;

        if (coins == 100)
        {
            AddLife();
            coins = coins - 100;
        }
    }

    public void AddLife()
    {
        lives++;
    }
}
