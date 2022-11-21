using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BotMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Target target;
    private Target[] targetsTMP;
    private List<Target> targets;

    //Присваивает агенту экземпляр компонента NavMeshAgent для этого бота. Получает значение скорости из собсственного скрипта бота и присваевает его своему компоненту NavMeshAgent
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = GetComponent<Bot>()._speed;
        GenerateTargetsList();
    }

    //Создаёт список доступных целей. Собирает все объекты, содержащие скрипт Target. Убирает из списка себя
    private void GenerateTargetsList()
    {
        targetsTMP = FindObjectsOfType<Target>();
        targets = new List<Target>(targetsTMP);
        targets.Remove(GetComponent<Target>());
    }

    //Убирает из списка всех 
    private void SetTarget()
    {
        if (targets.Count > 0)
        {
            target = targets[UnityEngine.Random.Range(0, targets.Count)];
            agent.destination = target.GetComponent<Transform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target == null)
        {
            GenerateTargetsList();
            if (targets.Count > 1)
            {
                SetTarget();
                Debug.Log(targets.Count);
            }
            else
            {
                agent.destination = GetComponent<Transform>().position;
                agent.isStopped = true;
            }
        }
        else
        {
            if (Vector3.Distance(agent.destination, target.GetComponent<Transform>().position) > 1f)
            {
                agent.destination = target.GetComponent<Transform>().position;
            }
            if (Vector3.Distance(target.GetComponent<Transform>().position, GetComponent<Transform>().position) < 2f)
            {
                GetComponent<BotDamage>().DoDamage(target);
            }
        }
    }
}
