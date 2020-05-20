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
            
            ObjectPooler.Instance.SpawnAllPooledObjects("Drone", -10f, 10f, -10f, 10f, Quaternion.identity);
        }
    }
}
