using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotDamage : MonoBehaviour
{
    private float _damage;
    private int _score=0;
    [SerializeField] private TMPro.TMP_Text _textScoreBoard;

    //Передаём скрипту начальный урон бота
    private void Start()
    {
        _damage = gameObject.GetComponentInParent<Bot>()._damage;
        _textScoreBoard.text = "Score: " + $"{_score}";
    }

    //Другая реализация. Пока не нужно. Хотя через триггер как-то получше работало
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Target target))
        {
            target.TakeDamage(_damage);
        }
    }

    //Нанести урон по target. Если получил True, добавляет себе поинт
    public void DoDamage(Target target)
    {
        if (target.TakeDamage(_damage))
        {
            _damage += 1;
            _score += 1;
            _textScoreBoard.text = "Score: " + $"{_score}";


        }
    }

}
