using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMovement : MonoBehaviour
{
    public float speed = 5f;
    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
    }
    void Update()
    {
        if (gm.currentScore % 25 == 0) speed += 0.1f;
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if(transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }
}