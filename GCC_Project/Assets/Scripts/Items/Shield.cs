using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerManager pm;

    void Start()
    {
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //pm = playerObj.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!GameObject.Find("Player").GetComponent<PlayerManager>().isShielded)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().isShielded = true;
            }
            Destroy(gameObject);
        }
    }
}