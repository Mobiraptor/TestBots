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
    private float damageRange = 2f;

    //����������� ������ ��������� ���������� NavMeshAgent ��� ����� ����. �������� �������� �������� �� ������������� ������� ���� � ����������� ��� ������ ���������� NavMeshAgent
    //Cashe NavMeshAgent in parameter. Sets speed for agent from Bot script. Generate initial target list
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = GetComponent<Bot>()._speed;
        GenerateTargetsList();
    }

    //������ ������ ��������� �����. �������� ��� �������, ���������� ������ Target. ������� �� ������ ����
    //Creating list containing all Objects with Target script. Removes itself from it
    private void GenerateTargetsList()
    {
        targetsTMP = FindObjectsOfType<Target>();
        targets = new List<Target>(targetsTMP);
        targets.Remove(GetComponent<Target>());
    }

    //�������� ���� ��������� ���� �� ������. ��������� �������� � ��������� ����
    //Chosing random target from list. Starts moving to target
    private void SetTarget()
    {
        if (targets.Count > 0)
        {
            target = targets[UnityEngine.Random.Range(0, targets.Count)];
            agent.destination = target.GetComponent<Transform>().position;
        }
    }

    void Update()
    {
        //���� ���� ���, �������� ����� ����, ���� �� ������� ����
        //If has no target and not alone choose new target
        if (target == null)
        {
            GenerateTargetsList();
            if (targets.Count > 0)
            {
                SetTarget();
            }
            else
            {
                agent.destination = GetComponent<Transform>().position;
                agent.isStopped = true;
            }
        }
        //����� ���� ����, ������������ ���������� ���� � ��������� �������� �� ����� �����������. ������� ����, ���� ��������� �� ����������� ���������� �� ����
        //If has target synchronizing coordinates. Calls Damage() in Target script if in range
        else
        {
            if (Vector3.Distance(agent.destination, target.GetComponent<Transform>().position) > 1f)
            {
                agent.destination = target.GetComponent<Transform>().position;
            }
            if (Vector3.Distance(target.GetComponent<Transform>().position, GetComponent<Transform>().position) < damageRange)
            {
                GetComponent<BotDamage>().DoDamage(target);
            }
        }
    }
}
