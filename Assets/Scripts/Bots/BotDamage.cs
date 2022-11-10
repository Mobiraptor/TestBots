using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDamage : MonoBehaviour
{
    private float _damage;

    private void Start()
    {
        _damage = GetComponentInParent<Bot>()._damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Target target))
        {
            target.TakeDamage(_damage);
        }
    }
    void Update()
    {
        
    }
}
