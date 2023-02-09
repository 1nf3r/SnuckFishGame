using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }
    
    public void PlayNormal(){
        SceneManager.LoadScene(3);
    }

    public void PlayHard(){
        SceneManager.LoadScene(4);
    }
}
