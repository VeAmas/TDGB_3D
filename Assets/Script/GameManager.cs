using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject successPanel;

    public void Success () {
        Debug.Log("Success");
        successPanel.SetActive(true);
    }

    public void EndGame () {
        if (!gameHasEnded) {
            gameHasEnded = true;
            Debug.Log("GameOver");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
