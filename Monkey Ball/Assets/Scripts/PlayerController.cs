using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource tickSource;
    public AudioSource jumpSound;

    private Scene scene;
    private Rigidbody rb;
    private int count;
    private int totalOfBananas = 12;
    private float jumpForce = 6f;
    private GameObject paused;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        paused = GameObject.FindGameObjectWithTag("Paused");
        Debug.Log(paused);
        scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);

        tickSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            Time.timeScale = 0;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Vector3 jumpVector = new Vector3(0, jumpForce, 0);
            rb.AddForce(jumpVector, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            tickSource.Play(); //Banana Sound
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            if (scene.name == "Monkey_Ball" && count >= totalOfBananas)
            {
                winText.text = "Level Complete!";

            }
            if (scene.name == "Monkey_Ball2" && count >= totalOfBananas)
            {
                winText.text = "You Win!";

            }
        }
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            SceneManager.LoadScene("menu_end");
        }
        if (other.gameObject.CompareTag("End") && count >= totalOfBananas)
        {
            SceneManager.LoadScene("Monkey_Ball2");
        }
        if (other.gameObject.CompareTag("Last_end") && count >= totalOfBananas)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void SetCountText()
    {
        countText.text = "Bananas: " + count.ToString();
        
    }
}
