using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 15f;
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
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }

    IEnumerator SizeReset()
    {
        yield return new WaitForSeconds(1f);
        transform.localScale = originalScale;
        isShielded = false;
    }
    void Shrink()
    {
        if (!isShrinked) return;
        transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);
        StartCoroutine(SizeReset());
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
    }
}
