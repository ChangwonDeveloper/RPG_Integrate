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
        if(Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }


    // PRIVATE METHODS
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit)
        {
            navMeshAgent.SetDestination(hit.point);
        }
    }
    private void UpdateAnimator()
    {
        Vector3 global_velocity = navMeshAgent.velocity;
        Vector3 local_velocity = transform.InverseTransformVector(global_velocity);
        float speed = local_velocity.z;
        animator.SetFloat("forwardSpeed", speed);
    }
}
