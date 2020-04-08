using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    private StaminaComponent sc;
    private PlayerMovement pm;

    [SerializeField]
    private float sprintCost = 20f, runspeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<StaminaComponent>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Run") && sc.CurrentStamina > 0)
        {
            pm.MoveSpeed = runspeed;
            sc.ReduceStamina(sprintCost);
        }

        else { pm.MoveSpeed = pm.WalkSpeed; }
    }
}
