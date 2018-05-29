using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Game_Music").GetComponent<Game_Music>().StopGameMusic();
        
    }
    public void play()
    {
        SceneManager.LoadScene("Monkey_Ball");
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
