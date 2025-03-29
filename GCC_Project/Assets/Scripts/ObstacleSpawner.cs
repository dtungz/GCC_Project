using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obsPrefabs;
    public float obsSpawnTime = 3f;
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
        GameObject obsSpawn = obsPrefabs[Random.Range(0,obsPrefabs.Length)];
        GameObject posSpawn = Instantiate(obsSpawn,transform.position,Quaternion.identity);
    }
}
