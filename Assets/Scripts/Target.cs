using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _health;

    private void Awake()
    {
        if (TryGetComponent<Bot>(out Bot bot))
        {
            _health = bot._health;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
