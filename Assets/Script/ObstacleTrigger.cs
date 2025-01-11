using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit obstacle!");

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
