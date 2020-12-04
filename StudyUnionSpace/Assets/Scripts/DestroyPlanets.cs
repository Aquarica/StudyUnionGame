using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyPlanets : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public Text countText;
    public Text gameOverText;
    public Text restartText;

    private int count; 

    //timer variable
    float currentTime = 0.0f;
    float startTime = 12.0f;
    public Text timerText;
    private bool timerActive = true;
    private bool playerActive = true;
    private bool restart = false;

    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = " ";
        restartText.text = " ";
        SetCountText();
        currentTime= startTime; 

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0 && timerActive)
        {
            currentTime = currentTime - 1* Time.deltaTime;
        }
        if (currentTime <= 0 && timerActive)
        {
            currentTime= 0;
            timerActive= false;
            LoseGame();
        }
        timerText.text = "Timer: " + currentTime.ToString("0.00");

        if(restart)
        {
            restartText.text = "Press 'R' to Restart";
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("SpaceGame");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Planet"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 3)
        {
            gameOverText.text = "You Win!";
            timerActive=false;
            restart=true;
        }
    }

    void LoseGame()
    {
        gameOverText.text = "You Lose!";
        playerActive= false;
        restart = true;
        Destroy(player);
    }
}
