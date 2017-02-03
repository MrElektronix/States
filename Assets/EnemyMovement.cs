using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _wanderPosition;
    public bool Wander = true ;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _wanderPosition = new Vector3(0,0,0);
    }

    private void Start()
    {
        StartCoroutine(StartWandering());
    }

    private IEnumerator StartWandering()
    {
        while (Wander)
        {
            var randomX = Random.Range(-4, 4);
            var randomY = Random.Range(-4, 4);

            _wanderPosition = new Vector3(randomX, 0, randomY);
            _navMeshAgent.SetDestination(_wanderPosition);

            var randomTime = Random.Range(1, 4);
            yield return new WaitForSeconds(randomTime);
        }
    }

    public void GoTo(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}
