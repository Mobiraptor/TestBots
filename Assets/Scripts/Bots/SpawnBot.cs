using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{

    [SerializeField] private GameObject _BotPrefab; //Поле для ссылки на префаб бота
    [SerializeField] private int _StartCount; //поле для количества ботов
    private int i = 0; //Счётчик для цикла создания ботов

    [SerializeField] private BotChars StatGenerator; //объект-генератор статов
    [SerializeField] private BotCoords CoordsGenerator; //объект-генератор координат

    private List<GameObject> BotInstances = new(); // Инициализация списка, куда будут записываться созданные боты
    private GameObject BotObject;


    //Создать _StartCount Количество ботов. Выдать им рандомные статы и координаты для спавна. Созданный бот добавляется в список
    void InitializeBot(Vector3 Coordinates)
    {
        BotObject = Instantiate(_BotPrefab);
        BotObject.GetComponent<Bot>().SetCharacteristics(StatGenerator.GetCharateristics());;
        BotObject.GetComponent<Bot>().SetSpawnCoordinates(Coordinates);
        BotInstances.Add(BotObject.gameObject);
    }

    //каждый кадр создаётся бот. Не в одном кадре
    private void Update()
    {
        if(i < _StartCount)
        {
            InitializeBot(CoordsGenerator.GetBotCoordinates());
            i++;
        }
    }
}
