using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotChars : MonoBehaviour
{
    //Блок для задания максимальных и минимальных статов в инспекторе
    [Header("Speed")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    [Header("Health")]
    [SerializeField] private float minHealth;
    [SerializeField] private float maxHealth;

    [Header("Damage")]
    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;

    //Формирование словаря со статами для передачи боту
    public Dictionary<string,float> GetCharateristics()
    {
        Dictionary<string, float> Stats = new Dictionary<string, float>()
        {
            { "Speed",GenerateCharacteristics(minSpeed, maxSpeed)}, 
            { "Health",GenerateCharacteristics(minHealth, maxHealth)},
            { "Damage",GenerateCharacteristics(minDamage, maxDamage)}
        };
        return Stats;
    }

    //Генерация стата
    private float GenerateCharacteristics(float min, float max)
    {
        return Random.Range(min, max);
    }


}
