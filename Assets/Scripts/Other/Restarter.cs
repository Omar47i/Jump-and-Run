using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    [SerializeField]
    private GameObject m_RestartButton;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.player || other.tag == Tags.player2)
        {
            // one of the two players have fallen, Display game over and stop the time, then restart
            Time.timeScale = 0f;

            m_RestartButton.SetActive(true);
        }
    }

    public void onRestartButton()
    {
        SceneManager.LoadScene("Main");

        Time.timeScale = 1f;
    }
}
