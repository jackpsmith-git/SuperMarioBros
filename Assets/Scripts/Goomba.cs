using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Sprite flatSprite;
    private GameManager gameManager;
    private GameObject mario;
    public AudioManager audioManager;

    private void Start()
    {
        mario =  GameObject.FindWithTag("Player");
        audioManager = mario.GetComponentInChildren<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower)
            {
                Hit();
                audioManager.kick.Play();
                gameManager.score = gameManager.score + 500;
            }
            else if (collision.transform.DotTest(transform, Vector2.down))
            {
                flatten();
                gameManager.score = gameManager.score + 100;
            }
            else
            {
                player.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
            gameManager.score = gameManager.score + 800;
        }
    }

    private void flatten()
    {
        audioManager.stomp.Play();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);
    }

    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        GetComponent<SpriteRenderer>().flipY = true;
        Destroy(gameObject, 3f);
    }
}
