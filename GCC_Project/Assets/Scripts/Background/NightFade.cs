using UnityEngine;

public class NightCycle : MonoBehaviour
{
    public float fadeDuration = 2f;
    public float waitDuration = 10f;

    private SpriteRenderer sr;
    private float timer = 0f;

    private enum State
    {
        WaitingBeforeFadeIn,
        FadingIn,
        WaitingBeforeFadeOut,
        FadingOut
    }

    private State currentState = State.WaitingBeforeFadeIn;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 0f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        switch (currentState)
        {
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
        }
    }
}