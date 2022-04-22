using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    GameObject wonUI;
    GameObject lostUI;
    GameObject pauseUI;
    bool gamePaused;

    void Awake()
    {
        wonUI = transform.GetChild(0).gameObject;
        lostUI = transform.GetChild(1).gameObject;
        pauseUI = transform.GetChild(2).gameObject;
    }

    public bool GamePaused(){
        return gamePaused;
    }

    public void ShowWonUI(){
        gamePaused = true;
        wonUI.SetActive(true);
    }

    public void ShowLostUI(){
        gamePaused = true;
        lostUI.SetActive(true);
    }

    public void ShowPauseUI(){
        gamePaused = true;
        pauseUI.SetActive(true);
    }

    public void HidePauseUI(){
        gamePaused = false;
        pauseUI.SetActive(false);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
