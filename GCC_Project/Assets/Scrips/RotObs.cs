using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotObs : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 150f;
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
