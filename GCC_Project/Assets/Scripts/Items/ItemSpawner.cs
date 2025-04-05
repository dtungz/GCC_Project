using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemsPrefabs;
    private GameManager gm;
    public float obsSpawnTime = 15f;
    private float countDown;
    private void Update()
    {
        if(GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
    }
    private void SpawnLoop()
    {
        countDown += Time.deltaTime;
        if(countDown >= obsSpawnTime)
        {
            Spawn();
            countDown = 0;
        }
    }
    private void Spawn()
    {
        GameObject obsSpawn = ItemsPrefabs[Random.Range(0,ItemsPrefabs.Length)];
        GameObject posSpawn = Instantiate(obsSpawn,transform.position,Quaternion.identity);
    }
}