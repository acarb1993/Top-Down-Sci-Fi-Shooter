using UnityEngine;

public class AttackMove : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private float damage;
    [SerializeField] private float coolDown;

    public float Cooldown {  get { return coolDown; } }

    public void Attack(GameObject target)
    {
        HealthComponent healthComponent = target.GetComponent<HealthComponent>();
        healthComponent.TakeDamage(damage);
    }
}
