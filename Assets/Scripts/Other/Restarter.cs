using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.player || other.tag == Tags.player2)
        {
            // one of the two players have fallen, Display game over and stop the time, then restart
            SceneManager.LoadScene("Main");
        }
    }
}
