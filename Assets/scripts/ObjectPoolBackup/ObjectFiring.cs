using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFiring : MonoBehaviour //this script is created so as to try something else if the first does not succeedd
{
    public ObjectPoolManager objectPoolManager; // Reference to the ObjectPoolManager.
    public Transform firePoint; // FirePoint
    public Vector3 fireDirection; // The direction the objects will be fired.
    public float fireForce = 10f; // Force
    public float fireInterval = 2f; // Time interval between shots

    private bool isFiring = false; // Flag to track if the thing is currently firing.

    void Start()
    {
        // Start the firing coroutine.
        StartCoroutine(FireObjectsPeriodically());
    }

    IEnumerator FireObjectsPeriodically()
    {
        while (true) // Keep firing indefinitely.
        {
            if (!isFiring)
            {
                GameObject obj = objectPoolManager.GetPooledObject();

                if (obj != null)
                {
                    obj.transform.position = firePoint.position;
                    obj.transform.rotation = Quaternion.identity;
                    obj.SetActive(true);

                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.velocity = fireDirection.normalized * fireForce;
                    }
                }

                isFiring = true;

                yield return new WaitForSeconds(fireInterval);

                isFiring = false;
            }
            yield return null;
        }
    }
}
