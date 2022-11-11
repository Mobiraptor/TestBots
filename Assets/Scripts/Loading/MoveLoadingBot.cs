using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//Скрипт для движения бота во время загрузки. По окончании движения переключает сцену
public class MoveLoadingBot : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 startPosition; //Начальная позиция бота
    public string nextSceneName; //Имя сцены, на которую переключится
    private int _distance = 30; //Дистанция, которую нужно будет проехать боту для переключения сцены

    //Вычисление начальных координат бота. Инициализация компонента NavMesh, задание координат для движения и отправка по этим координатам.
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetComponent<Transform>().position + new Vector3(_distance, 0,0);
        startPosition = GetComponent<Transform>().position;

    }
    private void Update()
    {
        //Проверяет, что бот доехал
        if(Vector3.Distance(startPosition,agent.GetComponent<Transform>().position)>_distance)
        {
            Debug.Log(nextSceneName);
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }      
    }
}
