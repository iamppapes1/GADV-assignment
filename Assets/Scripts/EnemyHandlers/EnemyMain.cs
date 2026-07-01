using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public GameObject[] buffs;
    private float _health = 100f;
    private float _damage = 10f;

    public void Init(float health, float damage)
    {
        _health = health;
        _damage = damage;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Debug.Log(_health);
        if(_health <= 0)
        {
            OnDeath();
        }
    }

    public float GetDamage()
    {
        return _damage;
    }

    void OnDeath()
    {
        int rng = Random.Range(1, buffs.Length);
        GameObject selectedBuff = buffs[rng - 1];
        GameObject buff = Instantiate(
            selectedBuff,
            gameObject.transform
        );
        buff.transform.parent = null;
        Destroy(gameObject);
    }
}
