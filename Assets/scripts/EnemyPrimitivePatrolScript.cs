using System.Collections;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2.0f;
    private int currentPoint = 0;

    private void Start()
    {
        if (patrolPoints.Length < 2)
        {
            Debug.LogWarning("PatrolController requires at least 2 patrol points.");
            enabled = false;
            return;
        }

        // Set the initial destination to the first patrol point
        SetDestination(patrolPoints[currentPoint]);
    }

    private void Update()
    {
        // Check if we've reached the current patrol point
        if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.1f)
        {
            // Move to the next patrol point
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            SetDestination(patrolPoints[currentPoint]);
        }
    }

    private void SetDestination(Transform destination)
    {
        // Calculate the direction to the destination
        Vector3 direction = (destination.position - transform.position).normalized;

        // Move the game object towards the destination
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
