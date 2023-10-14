using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private float GrappleSpeed = 30f;
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * GrappleSpeed; // Assuming you want to move in the X direction
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Point")) // Fixed the typo in "CompareTag"
        {
            gameObject.SetActive(false);
            Debug.Log("HIT");
        }
    }
}
