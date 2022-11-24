using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    //Перменные для здоровья и полоски
    //parameters for healthbar and health value
    [SerializeField] private float _health;
    private Slider HealthBar;

    //Скрипт смотрит, является ли объект ботом и подцепляет статы здоровья и и хпбар из его скрипта
    //lookung for a Bot component and gets health stat and healthbar from it
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

    //Function called by attacker. Does damage to itself. Synchronizing healthbar value. returns true when destroyed
    //Функция вызывается атакующим. Наносит урон Таргету(себе). Изменяет значение хпбара на актуальное. Передаёт true если убит.
    public bool TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            Destroy(gameObject);
            return true;
        }
        if (HealthBar)
        {
            HealthBar.value = _health;
        }
        return false;
    }
}
