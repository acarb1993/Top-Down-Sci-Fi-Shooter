/* Keeps the UI at the position of the player, this is used for the radial UI for the players Health and Stamina
 * Instead of the Health Bar and Stamina Bar being at the corner of the screen, you can see this and the player at the same 
 * position for keeping better track of these stats
 */

using UnityEngine;

public class ClampUI : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
