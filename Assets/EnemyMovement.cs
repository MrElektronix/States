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
    private bool _wander = true;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _wanderPosition = new Vector3(0,0,0);
    }

    private void Start()
    {
        StartCoroutine(Wander());
    }

    private IEnumerator Wander()
    {
        while (_wander)
        {
            var randomX = Random.Range(-4, 4);
            var randomY = Random.Range(-4, 4);

            _wanderPosition = new Vector3(randomX, 0, randomY);

            _navMeshAgent.SetDestination(_wanderPosition);
            yield return new WaitForSeconds(3);
        }
    }
}
