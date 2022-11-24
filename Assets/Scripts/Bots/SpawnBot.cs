using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{

    [SerializeField] private GameObject _BotPrefab; //Поле для ссылки на префаб бота/Field for Bot prefab
    [SerializeField] private int _StartCount; //поле для количества ботов/Amount of Bots to spawn settings
    private int i = 0; //Счётчик для цикла создания ботов/Counter for bot spawn

    [SerializeField] private BotChars StatGenerator; //объект-генератор статов/Stat generator script
    [SerializeField] private BotCoords CoordsGenerator; //объект-генератор координат/Coordinates generator script

    private List<GameObject> BotInstances = new(); // Инициализация списка, куда будут записываться созданные боты/List of Bot instances initialization
    private GameObject BotObject;


    //Создать _StartCount Количество ботов. Выдать им рандомные статы и координаты для спавна. Созданный бот добавляется в список
    //Create an instance of Bot with random stats and (by default) in random place
    void InitializeBot(Vector3 Coordinates)
    {
        BotObject = Instantiate(_BotPrefab);
        BotObject.GetComponent<Bot>().SetCharacteristics(StatGenerator.GetCharateristics());;
        BotObject.GetComponent<Bot>().SetSpawnCoordinates(Coordinates);
        BotInstances.Add(BotObject.gameObject);
    }

    //каждый кадр создаётся бот. Не в одном кадре
    //Create 1 Bot every frame, so it won't stutter
    private void Update()
    {
        if(i < _StartCount)
        {
            InitializeBot(CoordsGenerator.GetBotCoordinates());
            i++;
        }
    }
}
