using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obsPrefabs;
    private GameManager gm;
    public float obsSpawnTime = 3f;
    private float countDown;

    private void Start()
    {
        gm = GameManager.Instance;
    }
    private void Update()
    {
        if(GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
    }
    private void SpawnLoop()
    {
        if (gm.currentScore % 25.0f == 0) obsSpawnTime -= 0.1f;
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
