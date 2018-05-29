using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in this.transform)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                child.gameObject.SetActive(true);
            }

            if (Input.touchCount == 2)
            {
                child.gameObject.SetActive(true);
            }

        }
    }
    public void ContinueGame()
    {
        foreach (Transform child in this.transform)
        { 
            child.gameObject.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu_end");
    }
}
