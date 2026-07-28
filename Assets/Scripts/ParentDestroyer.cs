using UnityEngine;

public class ParentDestroyer : MonoBehaviour
{
    void Awake()
    {
        gameObject.transform.DetachChildren();
        Destroy(gameObject);
    }
}
