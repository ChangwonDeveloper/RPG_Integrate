using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target = null;

    NavMeshAgent navMeshAgent;
    Animator animator;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAnimator();
    }


    // PUBLIC METHODS
    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }


    // PRIVATE METHODS
    private void UpdateAnimator()
    {
        Vector3 global_velocity = navMeshAgent.velocity;
        Vector3 local_velocity = transform.InverseTransformVector(global_velocity);
        float speed = local_velocity.z;
        animator.SetFloat("forwardSpeed", speed);
    }
}
