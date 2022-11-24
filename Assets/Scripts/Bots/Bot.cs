using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bot : MonoBehaviour
{
    [Header("Stats")] //����������� ������ � ����������/Stats visualtisation in inspector
    [SerializeField] public float _speed;
    [SerializeField] public float _health;
    [SerializeField] public float _damage;

    //������ ����
    //Target object
    private GameObject Target;

    //��������� ��������� �������������, ���������� �� ��������
    //Bot stats setter
    public void SetCharacteristics(Dictionary<string, float> GotStats)
    {
        _speed = GotStats["Speed"];
        _health = GotStats["Health"];
        _damage = GotStats["Damage"];
    }

    //��������� ��������� ���������, ���������� �� ��������
    //Bot spawn coordinates setter
    public void SetSpawnCoordinates(Vector3 CoordVector)
    {
        GetComponent<Transform>().position = CoordVector;
    }
}
