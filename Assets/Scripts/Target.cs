using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    //Перменные для здоровья и полоски
    [SerializeField] private float _health;
    private Slider HealthBar;

    //Скрипт смотрит, является ли объект ботом и подцепляет статы здоровья и и хпбар из его скрипта
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

    //Функция вызывается атакующим. Наносит урон Таргету(себе). Изменяет значение хпбара на актуальное. Передаёт true если убит.
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
