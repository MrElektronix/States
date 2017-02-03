using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { WANDER,
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
            case State.ATTACK:
                _enemyMovement.Wander = false;
                _enemyMovement.GoTo(_currentTarget.position);

                break;
            case State.WANDER:
                _enemyMovement.Wander = true;

                break;
        }
    }

    public void Attack(Transform target)
    {
        //If the enemy has an enemy in his sight

        _currentState = State.ATTACK;
        _currentTarget = target;
    }
}
