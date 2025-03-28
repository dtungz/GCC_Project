using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMove : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
