using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject quitMenu;
    public TextMeshProUGUI highScoreTMP;


    public void ShowSettingMenu()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
        quitMenu.SetActive(false);
        

    }


    public void ShowQuitMenu()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
        quitMenu.SetActive(false);
        int maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (highScoreTMP != null)
            highScoreTMP.text = maxScore.ToString();
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("DukTofn");
    }    

    private void Start()
    {
        ShowMainMenu(); 
    }
}
