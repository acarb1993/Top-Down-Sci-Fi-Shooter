using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Spawn") ) {
            // Get random position 
            Vector3 position = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), 0);

            ObjectPooler.Instance.GetPooledObject("Drone", position, Quaternion.identity);
        }
    }
}
