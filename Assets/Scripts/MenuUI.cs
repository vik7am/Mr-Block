using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    public void LoadLevel(int level){
        SceneManager.LoadScene(level);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
