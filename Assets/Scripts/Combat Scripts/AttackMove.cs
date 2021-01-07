using UnityEngine;

public class AttackMove : MonoBehaviour
{
    [SerializeField] private float attackRange = 0f;
    [SerializeField] private float damage = 0f;
    [SerializeField] private float coolDown = 0f;

    public float Cooldown {  get { return coolDown; } }

    public void Attack(GameObject target)
    {
        HealthComponent healthComponent = target.GetComponent<HealthComponent>();
        healthComponent.TakeDamage(damage);
    }
}
