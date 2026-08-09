using UnityEngine;

public class Upgrader : MonoBehaviour
{
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.AddForce(Vector2.down * 50);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            if (gameObject.CompareTag("Damage Upgrade"))
            {
                Damage stat = other.GetComponent<Damage>();
                if (stat == null)
                {
                    Debug.LogWarning("Damage stat cannot be found");
                    return;
                }
                stat.Upgrade();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Firerate Upgrade"))
            {
                Firerate stat = other.GetComponent<Firerate>();
                if (stat == null)
                {
                    Debug.LogWarning("Firerate stat cannot be found");
                    return;
                }
                stat.Upgrade();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Health Upgrade"))
            {
                Health stat = other.GetComponent<Health>();
                if (stat == null)
                {
                    Debug.LogWarning("Health stat cannot be found");
                    return;
                }
                stat.Upgrade();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Object assigned wrong tag or is untagged");
            }
        }
    }
}