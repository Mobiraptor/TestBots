using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MoveLoadingBot : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 startPosition;
    public string nextSceneName;
    public float _timertmp;
    public float _timerMax;
    private int _distance = 30;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GetComponent<Transform>().position + new Vector3(_distance, 0,0);
        startPosition = GetComponent<Transform>().position;
        _timerMax = _distance/agent.speed+1f;

    }
    private void Update()
    {
        if(_timerMax <= _timertmp)
        {
            Debug.Log(nextSceneName);
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
        _timertmp += Time.deltaTime;
        
    }
}
