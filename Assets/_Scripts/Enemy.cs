﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    [SerializeField] public class  EnemyEvent : UnityEvent<Enemy>
    {

    }
    public EnemyEvent EnemyDied = new EnemyEvent();
    public void SetDestiation(Vector3 goalPos)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goalPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }

    }
    private void OnDisable()
    {
        EnemyDied?.Invoke(this);
        
    }
    private void OnDestroy()
    {
        EnemyDied?.Invoke(this);
    }



}
