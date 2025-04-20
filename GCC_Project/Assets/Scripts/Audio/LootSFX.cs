using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSFX : MonoBehaviour
{
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Items"))
        {
            audioManager.LootItem(audioManager.lootClip);
        }
    }
}
