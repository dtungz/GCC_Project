using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float fadeDuration = 2f;
    public float waitDuration = 10f;

    private SpriteRenderer sr;
    private float timer = 0f;

    private enum State
    {
        WaitingBeforeFadeOut,
        FadingOut,
        WaitingBeforeFadeIn,
        FadingIn
    }

    private State currentState = State.WaitingBeforeFadeOut;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        switch (currentState)
        {
            case State.WaitingBeforeFadeOut:
                if (timer >= waitDuration)
                {
                    timer = 0f;
                    currentState = State.FadingOut;
                }
                break;

            case State.FadingOut:
                float alphaOut = Mathf.Lerp(1f, 0f, timer / fadeDuration);
                sr.color = new Color(1f, 1f, 1f, alphaOut);

                if (timer >= fadeDuration)
                {
                    timer = 0f;
                    currentState = State.WaitingBeforeFadeIn;
                }
                break;

            case State.WaitingBeforeFadeIn:
                if (timer >= waitDuration)
                {
                    timer = 0f;
                    currentState = State.FadingIn;
                }
                break;

            case State.FadingIn:
                float alphaIn = Mathf.Lerp(0f, 1f, timer / fadeDuration);
                sr.color = new Color(1f, 1f, 1f, alphaIn);

                if (timer >= fadeDuration)
                {
                    timer = 0f;
                    currentState = State.WaitingBeforeFadeOut;
                }
                break;
        }
    }
}