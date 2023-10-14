using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Restart the current scene
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
