using UnityEngine;
using System.Collections;

public class ObstacleTrigger : MonoBehaviour
{
    private PlayerManager pm;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        pm = playerObj.GetComponent<PlayerManager>();
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