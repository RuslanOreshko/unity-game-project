using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject gameOverUI;

    private bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Spike") && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        animator.SetTrigger("Death");

        GetComponent<PlayerMovement>().enabled = false;

        Invoke(nameof(ShowGameOver), 1f);
    }

    private void ShowGameOver()
    {
        gameOverUI.SetActive(true);

        Time.timeScale = 0f;
    }
}
