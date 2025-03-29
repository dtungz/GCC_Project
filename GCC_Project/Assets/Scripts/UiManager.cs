using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    private GameManager gm;
    private string currentScore = "";
    private void Start()
    {
        gm = GameManager.Instance;
        UpdateScoreUI(gm.PrettyScore());
    }
    private void Update()
    {
        string score = gm.PrettyScore();
        if (score != currentScore)
        {
            UpdateScoreUI(score);
            currentScore = score;
        }
    }
    private void UpdateScoreUI(string score)
    {
        scoreUI.text = score;
    }
}