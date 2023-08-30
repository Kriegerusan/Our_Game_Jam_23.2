using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private Transform currentWaypoint, nextWaypoint;
    [SerializeField] private bool active;
    [SerializeField] private Trigger trigger;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Elevate(wayPoints[1]);
        }
        if (trigger != null)
        {
            if (trigger.GetTriggered())
            {
                active = true;
            }
        }
    }

    public void Elevate(Transform destination)
    {
        rigidBody.velocity = (destination.position - transform.position) * moveSpeed;
    }
}
