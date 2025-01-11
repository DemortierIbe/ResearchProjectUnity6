using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void EndGame()
    {
        Debug.Log("Game Over");
        // Restart the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
