using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class BotDamage : MonoBehaviour
{
    private float _damage;
    private float additionalDamage = 1f;
    private int _score=0;
    [SerializeField] private TMPro.TMP_Text _textScoreBoard;

    //������� ������� ��������� ���� ����. ����� ��������� ����� ���������� �����
    //Script gets initial damage from Bot. Set scoreboard text
    private void Start()
    {
        _damage = gameObject.GetComponentInParent<Bot>()._damage;
        _textScoreBoard.text = "Score: " + $"{_score}";
    }

    //������ ����������. ���� �� �����. ���� ����� ������� ���-�� ������� ��������
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Target target))
        {
            target.TakeDamage(_damage);
        }
    }*/

    //������� ���� �� target. ���� ������� True, ��������� ���� �����
    //Do damage on target. If gets true adds point and scale damage
    public void DoDamage(Target target)
    {
        if (target.TakeDamage(_damage))
        {
            _damage += additionalDamage;
            _score += 1;
            _textScoreBoard.text = "Score: " + $"{_score}";


        }
    }

}
