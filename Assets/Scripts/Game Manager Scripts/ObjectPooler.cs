/* Object Pooler will spawn objects in the game without Creating and Destroying Objects at runtime
 * Has multiple pools and can spawn any object to the gameworld, will create the objects and instead of 
 * destroying them it will put them into a Queue to be used again if needed.
 * 
 * This will now use given names of objects from a script rather than tags
 */

using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Pool Class

    /* Stores the object information of the Prefab that will be spawned from a pool.
     * You can assign a pool size, which is how many of the object you want in this pool.
     */
    [System.Serializable]
    private class Pool
    {
        [SerializeField] private string objectName = "";

        public string ObjectName { get { return objectName; } }

        [SerializeField] private GameObject prefab = null;

        public GameObject Prefab { get { return prefab; } }

        [SerializeField] private int size = 0;

        public int Size { get { return size; } }
    }

    #endregion

    [SerializeField] private List<Pool> pools = new List<Pool>();

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton

    // Only needs one Object Pool in the game
    private static ObjectPooler instance;
    public static ObjectPooler Instance { get { return instance; } }

    void Awake()
    {
        instance = this;

        if (instance == null) { instance = this; }

        else if (instance != this) { Destroy(gameObject); }
    }

    #endregion

    /* At the start the class will create Queues for each pool. 
     * It will take the size of the pool and enqueue that many objects.
     */
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> pooledObjects = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                pooledObjects.Enqueue(obj);
            }

            poolDictionary.Add(pool.ObjectName, pooledObjects);
        }
    }

    public GameObject GetPooledObject(string name, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(name))
        {
            Debug.LogWarning("Pool with name " + name + " does not exist!");

            return null;
        }

        foreach (GameObject go in poolDictionary[name])
        {
            // If the object isn't already in the scene...
            if (!go.activeInHierarchy)
            {
                // ...then add that object to the scene
                GameObject objectToSpawn = poolDictionary[name].Dequeue();

                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;

                objectToSpawn.SetActive(true);

                poolDictionary[name].Enqueue(objectToSpawn);

                return objectToSpawn;
            }
        }

        return null;       
    }

    // Spawn all objects in a pool at a position
    public void SpawnAllPooledObjects(string name, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(name))
        {
            Debug.LogWarning("Pool with name " + name + " does not exist!");
        }

        // For each loop will throw an exception
        for(int i = 0; i < poolDictionary[name].Count; i++)
        {
            // ...then add that object to the scene
            GameObject objectToSpawn = poolDictionary[name].Dequeue();
            if(!objectToSpawn.activeSelf)
            {
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;

                objectToSpawn.SetActive(true);

                poolDictionary[name].Enqueue(objectToSpawn);
            }
        }
    }

    // Spawn objects randomly within a range on the map
    public void SpawnAllPooledObjects(string name, float lowX, float highX, float lowY, float highY, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(name))
        {
            Debug.LogWarning("Pool with name " + name + " does not exist!");
        }

        // For each loop will throw an exception
        for (int i = 0; i < poolDictionary[name].Count; i++)
        {
            // ...then add that object to the scene
            GameObject objectToSpawn = poolDictionary[name].Dequeue();
            if (!objectToSpawn.activeSelf)
            {
                Vector3 position = new Vector3(Random.Range(lowX, highX), Random.Range(lowY, highY), 0);

                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;

                objectToSpawn.SetActive(true);

                poolDictionary[name].Enqueue(objectToSpawn);
            }
        }
    }
}
