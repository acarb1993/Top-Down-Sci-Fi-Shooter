/* This class allows any other class to access the player, this way if the Player is needed as a reference
 * Unity does not have to search the Hierarchy each time a class wants a reference to player which helps performance
 */

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    private static PlayerManager instance;

    public static PlayerManager Instance { get { return instance; } }

    public GameObject Player { get; private set; }

    public GameObject PlayerWeaponContainer { get; private set; }

    void Awake()
    {
        if (instance == null) { instance = this; }

        else if (instance != this) { Destroy(gameObject); }

        // Gets the player object in the scene
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null) { Debug.Log("No Player Found in Player Manager"); }
    }

    // Get the distance from an object to the player
    public static float GetDistanceToPlayer(GameObject gameObject)
    {
        if(gameObject.activeSelf)
        {
            return Vector2.Distance(gameObject.transform.position, instance.Player.transform.position);
        }

        return 0;
    }

    #endregion
}

