using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed, mobileSpeed;
    public Text countText;
    public Text winText;
    public AudioSource tickSource;

    private Scene scene;
    private Rigidbody rb;
    private int count;
    private int totalOfBananas = 12;
    private float jumpForce = 6f;
    private float jumpForceTouch = 4.8f;
    private float cooldown = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        scene = SceneManager.GetActiveScene();
        tickSource = GetComponent<AudioSource>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            Time.timeScale = 0;
        }

        if (Input.touchCount == 2)
        {
            Time.timeScale = 0;

        }
    }

    void FixedUpdate()
    {
            
            float initialOrientationX = Input.gyro.rotationRateUnbiased.x;
            float initialOrientationY = Input.gyro.rotationRateUnbiased.y;
            Vector3 mobileMovement = new Vector3(initialOrientationY, 0.0f, -initialOrientationX);
            rb.AddForce(mobileMovement * mobileSpeed);

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        
        if (Input.GetKeyDown(KeyCode.Space) && cooldown == 0)
        {
            cooldown = 1.5f;
            Vector3 jumpVector = new Vector3(0, jumpForce, 0);
            rb.AddForce(jumpVector, ForceMode.Impulse);
        }

        if (Input.touchCount == 1 && cooldown == 0)
        {
            cooldown = 1.5f;
            Vector3 jumpVector = new Vector3(0, jumpForceTouch, 0);
            rb.AddForce(jumpVector, ForceMode.Impulse);
        }

        if ( cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown < 0)
        {
            cooldown = 0f;
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
