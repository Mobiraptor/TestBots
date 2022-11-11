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

    //����������� ������ ��������� ���������� NavMeshAgent ��� ����� ����. �������� �������� �������� �� ������������� ������� ���� � ����������� ��� ������ ���������� NavMeshAgent
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = GetComponent<Bot>()._speed;
    }

    //������ ������ ��������� �����. �������� ��� �������, ���������� ������ Target. ������� �� ������ ����
    private void GenerateTargetsList()
    {
        targetsTMP = FindObjectsOfType<Target>();
        targets = new List<Target>(targetsTMP);
        targets.Remove(GetComponent<Target>());
    }

    //������� �� ������ ���� 
    private void SetTarget()
    {
        GenerateTargetsList();
        if (targets.Count > 0)
        {
            target = targets[UnityEngine.Random.Range(0, targets.Count)];
            agent.destination = target.GetComponent<Transform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTargetsList();
        if ((target==null) && (targets.Count>1))
        {
            SetTarget();
        }
        if(!(target == null))
        {
            if (Vector3.Distance(agent.destination, target.GetComponent<Transform>().position) > 1f)
            {
                agent.destination = target.GetComponent<Transform>().position;
            }
            if(Vector3.Distance(target.GetComponent<Transform>().position, GetComponent<Transform>().position) < 2f)
            {
                GetComponent<BotDamage>().DoDamage(target);
            }
        }
    }
}
