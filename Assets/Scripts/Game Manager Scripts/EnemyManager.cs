/* Will keep track of all Enemies currently in the game. */

using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton
    private static EnemyManager instance;

    public static EnemyManager Instance { get { return instance; } }

    void Awake()
    {
        if (instance == null) { instance = this; }

        else if (instance != this) { Destroy(gameObject); }

        list = new List<Enemy>();
    }

    void Start()
    {
        // Needs to be in start so player is initalized after PlayerManger runs it's Awake() method
        player = PlayerManager.Instance.Player;
    }

    #endregion

    private void Update()
    {
        spawnEnemy();
    }

    private List<Enemy> list;

    private GameObject player;

    public void AddEnemy(Enemy e) { list.Add(e); }

    public void RemoveEnemy(Enemy e) { list.Remove(e); }

    public void ClearList() { list.Clear(); }

    private void spawnEnemy()
    {
        // Spawns a drone at the mouse positon
        //Just for testing purposes, will be re-done at some point
        if(Input.GetKeyDown("space")) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            ObjectPooler.Instance.GetPooledObject("Drone", worldPos, new Quaternion(0, 0, 0, 0));
        }
    }
}
