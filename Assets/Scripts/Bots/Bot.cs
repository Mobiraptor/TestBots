using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bot : MonoBehaviour
{
    [Header("Stats")] //отображение статов в инспекторе
    [SerializeField] public float _speed;
    [SerializeField] public float _health;
    [SerializeField] public float _damage;

    //Объект цели
    private GameObject Target;

    //Установка случайных характеристик, полученных от спавнера
    public void SetCharacteristics(Dictionary<string, float> GotStats)
    {
        _speed = GotStats["Speed"];
        _health = GotStats["Health"];
        _damage = GotStats["Damage"];
    }

    //Установка случайных координат, полученных от спавнера
    public void SetSpawnCoordinates(Vector3 CoordVector)
    {
        GetComponent<Transform>().position = CoordVector;
    }
}
