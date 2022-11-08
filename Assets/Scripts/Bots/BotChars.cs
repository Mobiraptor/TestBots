using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotChars : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    [Header("Health")]
    [SerializeField] private float minHealth;
    [SerializeField] private float maxHealth;

    [Header("Damage")]
    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;

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

    private float GenerateCharacteristics(float min, float max)
    {
        return Random.Range(min, max);
    }


}
