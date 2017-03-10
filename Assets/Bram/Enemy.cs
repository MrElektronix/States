using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { WANDER,
                 GOTO,
                 ATTACK };

    private State _currentState;
    private Transform _currentTarget;

    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case State.GOTO:
                _enemyMovement.Wander = false;
                _enemyMovement.GoTo(_currentTarget.position);
                break;
            case State.WANDER:
                _enemyMovement.Wander = true;
                break;
            case State.ATTACK:
                break;
        }
    }

    public void Wander()
    {
        _currentState = State.WANDER;
    }

    public void GoTo(Transform target)
    {
        _currentState = State.GOTO;
        _currentTarget = target;
    }

    public void Attack()
    {
        _currentState = State.ATTACK;
    }
}
