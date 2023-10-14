using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    public Transform GrapplePosition; // Defines the GrapplePosition variable

    private void Fire()
    {
        GameObject Grapple = ObjectPool.instance.GetPooledObject();

        if (Grapple != null)
        {
            // Used  GrapplePosition.position instead of GrapplePosition.position() cause that was an issue that was WIERD
            Grapple.transform.position = GrapplePosition.position;
            Grapple.SetActive(true);
        }
    }
}
