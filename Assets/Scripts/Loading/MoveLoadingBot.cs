using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//������ ��� �������� ���� �� ����� ��������. �� ��������� �������� ����������� �����
public class MoveLoadingBot : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 startPosition; //��������� ������� ����
    public string nextSceneName; //��� �����, �� ������� ������������
    private int _distance = 30; //���������, ������� ����� ����� �������� ���� ��� ������������ �����

    //���������� ��������� ��������� ����. ������������� ���������� NavMesh, ������� ��������� ��� �������� � �������� �� ���� �����������.
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetComponent<Transform>().position + new Vector3(_distance, 0,0);
        startPosition = GetComponent<Transform>().position;

    }
    private void Update()
    {
        //���������, ��� ��� ������
        if(Vector3.Distance(startPosition,agent.GetComponent<Transform>().position)>_distance)
        {
            Debug.Log(nextSceneName);
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }      
    }
}
