/* Responsible for checking enemy aggro ranges for state changes */
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private float aggroDist = 2f;
    [SerializeField] private float disengageDist = 10f;
    [SerializeField] private float attackRange = 2f;

    public float AggroDistance { get { return aggroDist; } }
    public float DisengageDist {  get { return disengageDist; } }
    public float AtackRange { get { return attackRange; } }
}
