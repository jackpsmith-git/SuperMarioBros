using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject mario;
    public AudioManager audioManager;

    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower,
    }

    public Type type;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        mario =  GameObject.FindWithTag("Player");
        audioManager = mario.GetComponentInChildren<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
            gameManager.score = gameManager.score + 1000;
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin: 
                GameManager.Instance.AddCoin();
                audioManager.coin.Play();
                break;

            case Type.ExtraLife: 
                GameManager.Instance.AddLife();
                audioManager.oneUp.Play();
                break;

            case Type.MagicMushroom:
                player.GetComponent<Player>().Grow();
                audioManager.powerup.Play();
                break;

            case Type.Starpower:
                player.GetComponent<Player>().Starpower();
                audioManager.powerup.Play();
                break;
        }

        Destroy(gameObject);
    }
}
