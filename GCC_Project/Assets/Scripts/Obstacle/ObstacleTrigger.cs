using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;
using Debug = System.Diagnostics.Debug;

public class ObstacleTrigger : MonoBehaviour
{
    private PlayerManager pm;
    private AudioSource audio;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        pm = playerObj.GetComponent<PlayerManager>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pm.isInvincible) return;

            if (pm.isShielded)
            {
                StartCoroutine(DisableShield());
                return;
            }
            audio.Play();
            Time.timeScale = 0f;
            GameManager.Instance.GameOver();
        }
    }

    private IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(1f);
        pm.isShielded = false;
    }
}