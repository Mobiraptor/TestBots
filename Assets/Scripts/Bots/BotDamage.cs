using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotDamage : MonoBehaviour
{
    private float _damage;
    private int _score;
    private TMPro.TMP_Text _textScoreBoard;

    //������� ������� ��������� ���� ����
    private void Start()
    {
        _damage = gameObject.GetComponentInParent<Bot>()._damage;
        _score = gameObject.GetComponentInParent<Bot>()._score;
        _textScoreBoard.text = "Score:" + "{Score}";
    }

    //������ ����������. ���� �� �����. ���� ����� ������� ���-�� ������� ��������
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Target target))
        {
            target.TakeDamage(_damage);
        }
    }

    //������� ���� �� target
    public void DoDamage(Target target)
    {
        if (target.TakeDamage(_damage))
        {
            _damage += 1;
            _score += 1;
            _textScoreBoard.text = "Score:" + "{Score}";


        }
    }

}
