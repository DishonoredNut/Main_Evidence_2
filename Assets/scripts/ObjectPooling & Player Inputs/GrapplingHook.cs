using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public static ObjectPool instance; // Keep the type as ObjectPool
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private GameObject GrapplePrefab;
    public int PoolAmount = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = new ObjectPool(); // Create a new instance of ObjectPool (replace this with the actual way you create an ObjectPool instance)
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PoolAmount; i++)
        {
            GameObject obj = Instantiate(GrapplePrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
    
   
}
