using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour
{
    //private PlayerManager pm;
    void Start()
    {
        //pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameObject.Find("Player").GetComponent<PlayerManager>().isShrinked) return;
            else GameObject.Find("Player").GetComponent<PlayerManager>().isShrinked = true;
            Destroy(this.gameObject);
        }
    }
}