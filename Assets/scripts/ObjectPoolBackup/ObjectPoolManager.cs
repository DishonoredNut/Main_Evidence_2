using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject objectToPool; // Object I set
    public int poolSize = 10; // Given size of the object pool.

    private List<GameObject> objectPool;

    void Start()
    {
        objectPool = new List<GameObject>();

        // Filling the object pool with objects.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        // Find and return an inactive object from the pool.
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }

        // If no inactive objects are found, this should createa a new one and add it to the pool.
        GameObject newObj = Instantiate(objectToPool);
        newObj.SetActive(false);
        objectPool.Add(newObj);
        return newObj;
    }
}
