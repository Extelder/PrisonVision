using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianPatrollerAI : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform[] _waypoints;

    //[SerializeField] private Animator _animator;

    private int _currentWaypoint = 0;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _waypoints[_currentWaypoint].position) <= 1)
        {
            if (_currentWaypoint == _waypoints.Length - 1)
            {
                _currentWaypoint = 0;
            }
            else
            {
                _currentWaypoint++;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _movementSpeed * Time.deltaTime);

    }
}
