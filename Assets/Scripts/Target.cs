using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    //��������� ��� �������� � �������
    [SerializeField] private float _health;
    private Slider HealthBar;

    //������ �������, �������� �� ������ ����� � ���������� ����� �������� � � ����� �� ��� �������
    private void Start()
    {
        if (TryGetComponent<Bot>(out Bot bot))
        {
            _health = bot._health;
            HealthBar = GetComponentInChildren<Slider>();
            HealthBar.maxValue = _health;
            HealthBar.value = _health;
        }
    }

    //������� ���������� ���������. ������� ���� �������(����). �������� �������� ������ �� ����������. ������� true ���� ����.
    public bool TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            Destroy(gameObject);
            return true;
        }
        HealthBar.value = _health;
        return false;
    }
}
