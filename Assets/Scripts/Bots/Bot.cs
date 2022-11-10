using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<string,float> Stats;

    [Header("Stats")]
    [SerializeField] public float _speed;
    [SerializeField] public float _health;
    [SerializeField] public float _damage;

    [Header("Score")]
    [SerializeField] public int _score = 0;

    private GameObject Target;

    public void SetCharacteristics(Dictionary<string, float> GotStats)
    {
        Stats = GotStats;
        _speed = GotStats["Speed"];
        _health = GotStats["Health"];
        _damage = GotStats["Damage"];
    }

    public void SetSpawnCoordinates(Vector3 CoordVector)
    {
        GetComponent<Transform>().position = CoordVector;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
