using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Bot target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetTarget();
    }

    private void SetTarget()
    {
        var targets = FindObjectsOfType<Bot>();
        target = targets[Random.Range(0, targets.Length)];
        //while(target == GetComponentInParent<Bot>())
        {
            //target = targets[Random.Range(0, targets.Length)];
        }
        agent.destination = target.GetComponent<Transform>().position;

    }
    // Update is called once per frame
    void Update()
    {
        if (target==null)
        {
            SetTarget();
        }
    }
}
