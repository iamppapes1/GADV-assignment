using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}
