using UnityEngine;

public class ObjectMuncher9000 : MonoBehaviour
{
    //Utility script. Deletes objects that goes beyond the screen (bullets, enemies, powerups)
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
