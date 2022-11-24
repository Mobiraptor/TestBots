using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{

    [SerializeField] private GameObject _BotPrefab; //���� ��� ������ �� ������ ����/Field for Bot prefab
    [SerializeField] private int _StartCount; //���� ��� ���������� �����/Amount of Bots to spawn settings
    private int i = 0; //������� ��� ����� �������� �����/Counter for bot spawn

    [SerializeField] private BotChars StatGenerator; //������-��������� ������/Stat generator script
    [SerializeField] private BotCoords CoordsGenerator; //������-��������� ���������/Coordinates generator script

    private List<GameObject> BotInstances = new(); // ������������� ������, ���� ����� ������������ ��������� ����/List of Bot instances initialization
    private GameObject BotObject;


    //������� _StartCount ���������� �����. ������ �� ��������� ����� � ���������� ��� ������. ��������� ��� ����������� � ������
    //Create an instance of Bot with random stats and (by default) in random place
    void InitializeBot(Vector3 Coordinates)
    {
        BotObject = Instantiate(_BotPrefab);
        BotObject.GetComponent<Bot>().SetCharacteristics(StatGenerator.GetCharateristics());;
        BotObject.GetComponent<Bot>().SetSpawnCoordinates(Coordinates);
        BotInstances.Add(BotObject.gameObject);
    }

    //������ ���� �������� ���. �� � ����� �����
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
