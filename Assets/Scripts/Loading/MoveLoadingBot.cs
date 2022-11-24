using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//������ ��� �������� ���� �� ����� ��������. �� ��������� �������� ����������� �����
//Loading screen script

public class MoveLoadingBot : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 startPosition; //��������� ������� ����/Bot starting position
    public string nextSceneName; //��� �����, �� ������� ������������/Next scene name
    private int _distance = 30; //���������, ������� ����� ����� �������� ���� ��� ������������ �����/Distatnce that bot should move before changing scene

    //���������� ��������� ��������� ����. ������������� ���������� NavMesh, ������� ��������� ��� �������� � �������� �� ���� �����������.
    //Getting bot starting position. Navmesh component init. Setting destination for loading boot.
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetComponent<Transform>().position + new Vector3(_distance, 0,0);
        startPosition = GetComponent<Transform>().position;

    }
    private void Update()
    {
        //���������, ��� ��� ������ ��, �������� ��� ������������ �����, �����
        //Checks if bot moved to it's destination
        if(Vector3.Distance(startPosition,agent.GetComponent<Transform>().position)>_distance)
        {
            Debug.Log(nextSceneName);
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }      
    }
}
