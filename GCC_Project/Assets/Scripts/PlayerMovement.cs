using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }
}
