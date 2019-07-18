using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    //public Component arrayOfHearts;
    //public GameObject[] hearts;
    public GameObject introMessage;
    public GameObject pauseMenu;
    public GameObject victoryMessage;
    public GameObject gameOverMessage;
    public bool gameOver;
    public int coinCollected;
    public int targetCoins;

    public int life;


    public GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        // Initials vars
        coinCollected = 0;
        targetCoins = 5;
        gameOver = false;
        life = 3;

        //Hide UI
        introMessage.SetActive(true);
        pauseMenu.SetActive(false);
        victoryMessage.SetActive(false);
        gameOverMessage.SetActive(false);

        //hearts = arrayOfHearts.GetComponentsInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            introMessage.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause(!pauseMenu.activeInHierarchy);
        }
    }

    public void TogglePause(bool state) {
        if (!gameOver) {
            pauseMenu.SetActive(state);
            if (state)  {
                print("Pause");
                Time.timeScale = 0f;
            }else {
                Time.timeScale = 1f;
            }
        }
    }
    void GameOver(bool won) {
        gameOver=true;
        if (won) {
            victoryMessage.SetActive(true);
        }else {
            gameOverMessage.SetActive(true);
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void CoinCollect() {
        Debug.Log("COLLECTTED");
        coinCollected++;
        if (coinCollected >= targetCoins ) {
            GameOver(true);
        }
    }

    public void LifeLost() {
        life--;
    
        // Remove life starting from end;
        if (hearts.Length > 0) {
            Destroy(hearts[life]);
        }

        if (life <= 0) {
            GameOver(false);
        }
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
    }
    public void Quit() {
        Application.Quit();
    }
}
