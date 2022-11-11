using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{

    [SerializeField] private GameObject _BotPrefab; //���� ��� ������ �� ������ ����
    [SerializeField] private int _StartCount; //���� ��� ���������� �����
    private int i = 0; //������� ��� ����� �������� �����

    [SerializeField] private BotChars StatGenerator; //������-��������� ������
    [SerializeField] private BotCoords CoordsGenerator; //������-��������� ���������

    private List<GameObject> BotInstances = new(); // ������������� ������, ���� ����� ������������ ��������� ����
    private GameObject BotObject;


    //������� _StartCount ���������� �����. ������ �� ��������� ����� � ���������� ��� ������. ��������� ��� ����������� � ������
    void InitializeBot(Vector3 Coordinates)
    {
        BotObject = Instantiate(_BotPrefab);
        BotObject.GetComponent<Bot>().SetCharacteristics(StatGenerator.GetCharateristics());;
        BotObject.GetComponent<Bot>().SetSpawnCoordinates(Coordinates);
        BotInstances.Add(BotObject.gameObject);
    }

    //������ ���� �������� ���. �� � ����� �����
    private void Update()
    {
        if(i < _StartCount)
        {
            InitializeBot(CoordsGenerator.GetBotCoordinates());
            i++;
        }
    }
}
