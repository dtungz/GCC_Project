using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
            if(Instance == null)
                Instance = this;
    }

    #endregion
    public float currentScore = 0f;
    public bool isPlaying = false;
    public GameObject gameOverMenu;
    public GameObject PauseSetting;
    private bool gameStarted = false;
    private bool isGameOver = false;


    public void ShowPause()
    {
        Time.timeScale = 0f;
        PauseSetting.SetActive(true);
    }

    public void ReturnPlay()
    {
        Time.timeScale = 1f;
        PauseSetting.SetActive(false);
    }
    private void Start()
    {
        currentScore = 0;
        Time.timeScale = 0f;
        isPlaying = false;
        gameStarted = false;
        isGameOver = false;
        PauseSetting.SetActive(false );
        if(gameOverMenu != null )
            gameOverMenu.SetActive(false);

    }
    private void Update()
    {
        if(isPlaying)
        {
            currentScore += Time.deltaTime;
        }
        if( !isGameOver  && !gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            isPlaying = true;
            Time.timeScale = 1f;
            gameStarted = true;
        }
    }
    public void GameOver()
    {
        isPlaying = false ;
        isGameOver = true;
        Time.timeScale = 0f;

        if( gameOverMenu != null )
            gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BackMenu()
    {
        SceneManager.LoadScene("main_menu");
    }    

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
