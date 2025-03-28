using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bx;
    private void Update()
    {
        OnTriggerEnter2D(bx);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
