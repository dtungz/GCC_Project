using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MayScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] May;
    [SerializeField] private float scrollSpeed = 0.75f;
    private float width;
    float getRightMost()
    {
        float max = May[0].transform.position.x;
        foreach (GameObject go in May)
        {
            if (go.transform.position.x > max)
            {
                max = go.transform.position.x;
            }
        }
        return max;
    }
    void Start()
    {
        width = May[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        foreach (GameObject mountain in May)
        {
            mountain.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
            if (mountain.transform.position.x < -width - 1.5f)
            {
                float rightMost = getRightMost();
                mountain.transform.position = new Vector3(rightMost + width - 0.01f, mountain.transform.position.y, mountain.transform.position.z);
            }
        }
    }
}