using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bot : MonoBehaviour
{
    [Header("Stats")] //îòîáðàæåíèå ñòàòîâ â èíñïåêòîðå/Stats visualisation in inspector
    [SerializeField] public float _speed;
    [SerializeField] public float _health;
    [SerializeField] public float _damage;

    //Îáúåêò öåëè
    //Target object
    private GameObject Target;

    //Óñòàíîâêà ñëó÷àéíûõ õàðàêòåðèñòèê, ïîëó÷åííûõ îò ñïàâíåðà
    //Bot stats setter
    public void SetCharacteristics(Dictionary<string, float> GotStats)
    {
        _speed = GotStats["Speed"];
        _health = GotStats["Health"];
        _damage = GotStats["Damage"];
    }

    //Óñòàíîâêà ñëó÷àéíûõ êîîðäèíàò, ïîëó÷åííûõ îò ñïàâíåðà
    //Bot spawn coordinates setter
    public void SetSpawnCoordinates(Vector3 CoordVector)
    {
        GetComponent<Transform>().position = CoordVector;
    }
}
