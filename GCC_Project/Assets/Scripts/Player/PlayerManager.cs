using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float force = 15f;
    [SerializeField] Rigidbody2D rb;
    public bool isShielded;
    public bool isInvincible;
    public bool isShrinked;
    public bool canBeTrigger;
    private Vector3 originalScale;

    void Move()
    {
        if(Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Force);
        }
    }
    IEnumerator SizeReset()
    {
        yield return new WaitForSeconds(8f);
        transform.localScale = originalScale;
        isShrinked = false;
    }

    IEnumerator InvincibleReset()
    {
        yield return new WaitForSeconds(8f);
        isInvincible = false;
    }
    private void Invincible()
    {
        if (isInvincible)
        {
            if (InvincibleReset() != null) StopCoroutine(InvincibleReset());
            StartCoroutine(InvincibleReset());
        }
        else return;
    }
    private void Shrink()
    {
        if (isShrinked && transform.localScale.x > originalScale.x * 0.5f)
        {
            transform.localScale = new Vector3(
                originalScale.x * 0.5f, 
                originalScale.y * 0.5f,
                originalScale.z
            );
            StartCoroutine(SizeReset());
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isShielded = false;
        isInvincible = false;
        isShrinked = false;
        canBeTrigger = true;
        originalScale = transform.localScale;
    }

    void Update()
    {
        Move();
        if (isShrinked) Shrink();
        Invincible();
    }
}

