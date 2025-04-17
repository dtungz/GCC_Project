using UnityEngine;

public class BackgroundTransition : MonoBehaviour
{
    public SpriteRenderer nightBackground;
    public float transitionDuration = 20f;

    public float targetAlpha = 0f;
    public float currentAlpha = 0f;

    private void Update()
    {
        currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime / transitionDuration);
        
        Color c = nightBackground.color;
        c.a = currentAlpha;
        nightBackground.color = c;
    }

    public void SetToNight()
    {
        targetAlpha = 1f;
    }

    public void SetToDay()
    {
        targetAlpha = 0f;
    }
}
