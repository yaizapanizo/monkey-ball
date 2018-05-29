using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject[] songs;
    private void Start()
    {

        songs = GameObject.FindGameObjectsWithTag("Game_Music");
        
        foreach (GameObject Game_Music in songs)
        {
            GameObject.FindGameObjectWithTag("Game_Music").SetActive(false);
        } 
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
