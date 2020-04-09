/* Determines what the enemy will do when chasing the player.
 * The Enemy will stop and attack the player once it's in range.
 * When out of range, it will continue to chase until back in range.
 */

using UnityEngine;

public class EnemyChaseBehavior : StateMachineBehaviour
{
    [SerializeField]
    private EnemyStats enemyStats;

    private DistanceToPlayer dtp;

    private EnemyMeleeAttack ema;

    private Transform playerPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = PlayerManager.Instance.Player.transform;

        dtp = animator.GetComponent<DistanceToPlayer>();
        if (dtp == null) { Debug.Log("Can't find distance to player"); }

        ema = animator.GetComponent<EnemyMeleeAttack>();
        if (ema == null) { Debug.Log("Enemy Melee Attack not found"); }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FaceTarget(animator);

        if (!ema.IsInRange)
        {
            animator.transform.position = Vector2.MoveTowards
                (animator.transform.position, 
                playerPos.position, 
                enemyStats.WalkSpeed * Time.deltaTime );
        }     
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

     //OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    // Makes the enemy face the player when chasing
    private void FaceTarget(Animator anim) { anim.transform.up = playerPos.position - anim.transform.position; }
}
