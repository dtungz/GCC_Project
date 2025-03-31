using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if(transform.position.x < -25)
        {
            Destroy(gameObject);
        }

    }
}
