using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            GameManager.Instance.ResetLevel(2f);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
