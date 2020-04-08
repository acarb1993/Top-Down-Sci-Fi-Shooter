/* Gives enemies a short range attack to hit the players Health Component when in range. 
 * It will check to see if the Player is in range before attacking, as  well as
 * respecting a cooldown timer between attacks
 */

using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField]
    private int cooldown = 3;

    [SerializeField]
    private float damage = 10, range = 2;

    private float timer = 0;

    public bool IsInRange { get; private set; }

    private DistanceToPlayer distToPlayer;

    private HealthComponent playerHealth;

    private GameObject player;

    void Start()
    {
        distToPlayer = GetComponent<DistanceToPlayer>();
        player = PlayerManager.Instance.Player;
        playerHealth = player.GetComponent<HealthComponent>();
    }

    private void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }

        if (distToPlayer.playerDistance <= range) { IsInRange = true; }

        else { IsInRange = false; }

        if ( IsInRange && timer <= 0) { Attack(playerHealth); }
    }

    public void Attack(HealthComponent hc)
    {
        hc.TakeDamage(damage);

        timer = cooldown;
    }
}
