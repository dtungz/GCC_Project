using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public int maxScore = 0;
    public bool isPlaying = false;
    public GameObject gameOverMenu;
    public GameObject PauseSetting;
    public GameObject PressSpace;
    public GameObject StopButton;
    private bool gameStarted = false;
    private bool isGameOver = false;
    public TextMeshProUGUI highScoreTMP;
    public TextMeshProUGUI currentScoreTMP;
    public TextMeshProUGUI scoreTMP;




    public void ShowPause()
    {
        Time.timeScale = 0f;
        PauseSetting.SetActive(true);
        if (PressSpace != null)
            PressSpace.SetActive(false);
    }

    public void ReturnPlay()
    {
        Time.timeScale = 1f;
        PauseSetting.SetActive(false);
        if (PressSpace == null)
            PressSpace.SetActive(true);
    }
    private void Start()
    {
        currentScore = 0;
        Time.timeScale = 0f;
        isPlaying = false;
        PressSpace.SetActive(true );
        gameStarted = false;
        isGameOver = false;
        PauseSetting.SetActive(false );
        
        if(gameOverMenu != null )
            gameOverMenu.SetActive(false);
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);

    }
    private void Update()
    {
        if(isPlaying)
        {
            currentScore += Time.deltaTime;
            if (scoreTMP != null)
                scoreTMP.text = "Score: " + PrettyScore();
        }
        if( !isGameOver  && !gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            PressSpace.SetActive(false) ;
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
        int finalScore = Mathf.RoundToInt(currentScore);
        if (finalScore > maxScore)
        {
            maxScore = finalScore;
            PlayerPrefs.SetInt("MaxScore", maxScore);
            PlayerPrefs.Save(); 
        }
        if (highScoreTMP != null)
            highScoreTMP.text = "HighScore : " + maxScore.ToString();
        if (scoreTMP != null)
            scoreTMP.gameObject.SetActive(false);
        if (currentScoreTMP != null)
            currentScoreTMP.text = PrettyScore();

        StopButton.SetActive(false ) ;
        if( gameOverMenu != null )
            gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        if (scoreTMP != null)
            scoreTMP.gameObject.SetActive(true );
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BackMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu");
    }    

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
