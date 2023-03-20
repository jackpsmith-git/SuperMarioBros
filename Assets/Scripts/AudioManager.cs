using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject mario;
    private GameManager gameManager;
    public AudioSource overworldTheme;
    public AudioSource undergroundTheme;
    public AudioSource gameOver;
    public AudioSource marioHit;
    public AudioSource stageClear;
    public AudioSource hurryUp;
    public AudioSource oneUp;
    public AudioSource bump;
    public AudioSource coin;
    public AudioSource flagpole;
    public AudioSource smallJump;
    public AudioSource bigJump;
    public AudioSource kick;
    public AudioSource pipe_powerDown;
    public AudioSource powerup;
    public AudioSource powerupAppears;
    public AudioSource stomp;
    public AudioSource starman;


    void Start()
    {
        mario =  GameObject.FindWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();

        overworldTheme.enabled = true;
        undergroundTheme.enabled = true;
        overworldTheme.Play();
        undergroundTheme.Stop();
    }
}
