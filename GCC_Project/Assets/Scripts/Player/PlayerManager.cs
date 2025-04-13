using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float force = 15f;
    [SerializeField] private Rigidbody2D rb;

    public bool isShielded;
    public bool isInvincible;
    public bool isShrinked;

    private Vector3 originalScale;
    private Coroutine invincibleCoroutine;
    private Coroutine shrinkCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isShielded = false;
        isInvincible = false;
        isShrinked = false;
        originalScale = transform.localScale;
    }

    void Update()
    {
        Move();

        if (isShrinked && shrinkCoroutine == null)
        {
            shrinkCoroutine = StartCoroutine(ShrinkReset());
        }

        if (isInvincible && invincibleCoroutine == null)
        {
            invincibleCoroutine = StartCoroutine(InvincibleReset());
        }
    }

    private void Move()
    {
        if (Input.GetButton("Jump"))
        {
            rb.gravityScale = -1;
        }
        else rb.gravityScale = 1;   
    }

    private IEnumerator ShrinkReset()
    {
        transform.localScale = new Vector3(
            originalScale.x * 0.5f,
            originalScale.y * 0.5f,
            originalScale.z
        );

        yield return new WaitForSeconds(8f);

        transform.localScale = originalScale;
        isShrinked = false;
        shrinkCoroutine = null;
    }

    private IEnumerator InvincibleReset()
    {
        yield return new WaitForSeconds(8f);
        isInvincible = false;
        invincibleCoroutine = null;
    }
}