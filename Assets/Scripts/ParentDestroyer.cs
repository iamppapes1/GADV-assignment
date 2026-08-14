using UnityEngine;

public class ParentDestroyer : MonoBehaviour
{
    //Purely utility. It's used on my bullets as they dont delete themselves when all the bullets are destroyed
    void Awake()
    {
        gameObject.transform.DetachChildren();
        Destroy(gameObject);
    }
}
