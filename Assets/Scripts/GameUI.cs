using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject wonUI;
    public GameObject lostUI;
    public GameObject pauseUI;
    bool gamePaused = false;
    int totalScene;

    private void Awake() {
        totalScene = SceneManager.sceneCountInBuildSettings;
    }

    public bool GamePaused(){
        return gamePaused;
    }

    public void ShowUI(Panel panel){
        switch(panel){
            case Panel.WON : wonUI.SetActive(true); break;
            case Panel.LOST : lostUI.SetActive(true); break;
            case Panel.PAUSE : pauseUI.SetActive(true); break;
        }
        gamePaused = true;
    }

    public void HidePauseUI(){
        gamePaused = false;
        pauseUI.SetActive(false);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void NextLevel(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentLevel + 1) % totalScene);
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
