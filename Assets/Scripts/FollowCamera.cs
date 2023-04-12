using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    // To make camera to move along character use lateupdate
    void LateUpdate()
    {
        this.transform.position = target.position;
    }
}
