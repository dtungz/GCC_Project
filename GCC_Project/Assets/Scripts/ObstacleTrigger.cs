using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private PlayerManager pm;
    IEnumerator CollsionReset()
    {
        yield return new WaitForSeconds(1f);
        if (!pm.isInvincible) pm.canBeTrigger = true;
    }
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pm.isInvincible) return;
            if (pm.isShielded && pm.canBeTrigger)
            {
                pm.canBeTrigger = false;
                StartCoroutine(CollsionReset());
                return;
            }
        }
        Time.timeScale = 0;
        GameManager.Instance.GameOver();
    }
}
