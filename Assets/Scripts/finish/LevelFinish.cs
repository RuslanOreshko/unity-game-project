using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    private void Start()
    {
        KeyPickup.HasKey = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && KeyPickup.HasKey)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }
}