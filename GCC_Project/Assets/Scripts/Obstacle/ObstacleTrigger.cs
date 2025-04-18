using UnityEngine;
using System.Collections;

public class ObstacleTrigger : MonoBehaviour
{
    //private PlayerManager pm;
    //private AudioSource audio;

    void Start()
    {
        //pm = GameObject.Find("Player").GetComponent<PlayerManager>();
        //audio = GetComponent<AudioSource>();
        //if (audio == null)
        //{
        //    Debug.LogWarning("AudioSource không được gắn vào ObstacleTrigger.");
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Trigger với Player!");

        if (GameObject.Find("Player").GetComponent<PlayerManager>().isInvincible)
        {
            return;
        }

        if (GameObject.Find("Player").GetComponent<PlayerManager>().isShielded)
        {
            Debug.Log("Player có khiên, hấp thụ va chạm.");
            StartCoroutine(DisableShield());
            return;
        }

        Debug.Log("Player không có khiên hay bất tử -> Game Over!");
        // Nếu bạn cần AudioSource, kiểm tra lại xem có null không
        //if (audio != null) audio.Play();

        Time.timeScale = 0f;
        GameManager.Instance.GameOver();
    }

    private IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Player").GetComponent<PlayerManager>().isShielded = false;
        Debug.Log("Khiên đã tắt sau 1 giây.");
    }
}