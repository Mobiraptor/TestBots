using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    [SerializeField] private GameObject _BotPrefab;
    [SerializeField] private int _StartCount;

    [SerializeField] private BotChars _StatGenerator;

    private List<GameObject> BotInstances = new List<GameObject>();
    private GameObject BotObject;

    //Spawn {_StartCount} amount of bots. Assing htem random stats. Add spawned bots instances into list
    void Start()
    {
        for (int i = 0; i < _StartCount; i++)
        {
            BotObject = Instantiate(_BotPrefab);
            BotObject.GetComponent<Bot>().SetCharacteristics(_StatGenerator.GetCharateristics());
            BotInstances.Add(BotObject.gameObject);
        }
    }
}
