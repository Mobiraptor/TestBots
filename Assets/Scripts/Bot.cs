using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<string,float> Stats;

    [Header("Stats")]
    [SerializeField] float _speed;
    [SerializeField] float _health;
    [SerializeField] float _damage;

    public void SetCharacteristics(Dictionary<string, float> GotStats)
    {
        Stats = GotStats;
        _speed = GotStats["Speed"];
        _health = GotStats["Health"];
        _damage = GotStats["Damage"];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
