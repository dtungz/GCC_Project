using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    //private PlayerManager pm;
    void Start()
    {
        //pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<AudioSource>().Play();
        if (other.CompareTag("Player"))
        {
            if (GameObject.Find("Player").GetComponent<PlayerManager>().isInvincible) return;
            else GameObject.Find("Player").GetComponent<PlayerManager>().isInvincible = true;
            Destroy(this.gameObject);
        }
    }
}