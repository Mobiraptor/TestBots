using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    [SerializeField] private GameObject _BotPrefab;
    [SerializeField] private int _StartCount;
    private int i = 0;

    [SerializeField] private BotChars StatGenerator;
    [SerializeField] private BotCoords CoordsGenerator;

    private List<GameObject> BotInstances = new();
    private GameObject BotObject;


    void Start()
    {
    }

    //Spawn {_StartCount} amount of bots. Assing them random stats and position. Add spawned bot instance into list
    void InitializeBots()
    {
        BotObject = Instantiate(_BotPrefab);
        BotObject.GetComponent<Bot>().SetCharacteristics(StatGenerator.GetCharateristics());;
        BotObject.GetComponent<Bot>().SetSpawnCoordinates(CoordsGenerator.GetBotCoordinates());
        BotInstances.Add(BotObject.gameObject);
    }

    private void Update()
    {
        if(i < _StartCount)
        {
            InitializeBots();
            i++;
        }
    }
}
