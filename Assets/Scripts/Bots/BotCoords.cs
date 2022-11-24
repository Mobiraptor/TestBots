using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCoords : MonoBehaviour
{
    //����������� ������ ������ (���� ���������, ��� ��� ��� ��������� �� ������)
    //Height of spawn
    [SerializeField] private float y;

    //���� ��������� ������ (��� �������, � �������), �� ������� ����� ����� ����������
    //Plane (Planes in future) where bot can spawn

    [SerializeField] private MeshRenderer PlaneBounds;

    private Vector3 BotWantedCoords;

    //������������ �������� �����������. �������� ����� ��� ��������� ���������, ���� �� ������� �����, ��� ������ ��� � �������� �������� �� �������� 2
    //Coordinates passer. Checks if there is another object in wanted coordinates. Passes coordinates if finds no obstacles

    public Vector3 GetBotCoordinates()
    {
        BotWantedCoords = GenerateCoordinates();
        while (Physics.BoxCast(BotWantedCoords, new Vector3(2, 2, 2), new Vector3(2, 2, 2), Quaternion.Euler(0, 0, 0), 2))    //�� ���� ������ ��������� ��������� ����� � ������, �� ��� ���-�� �� ������ ��������...
        {
            BotWantedCoords = GenerateCoordinates();
        }
        return BotWantedCoords;

    }

    //��������� �����������
    //spawn coordinates generation
    private Vector3 GenerateCoordinates()
    {
        return new Vector3(Random.Range(PlaneBounds.bounds.min.x + 1, PlaneBounds.bounds.max.x - 1), y, Random.Range(PlaneBounds.bounds.min.z + 1, PlaneBounds.bounds.max.z - 1));
    }
}
