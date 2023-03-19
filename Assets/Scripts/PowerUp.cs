using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameManager gameManager;

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
                break;

            case Type.ExtraLife: 
                GameManager.Instance.AddLife();
                break;

            case Type.MagicMushroom:
                player.GetComponent<Player>().Grow();
                break;

            case Type.Starpower:
                player.GetComponent<Player>().Starpower();
                break;
        }

        Destroy(gameObject);
    }
}
