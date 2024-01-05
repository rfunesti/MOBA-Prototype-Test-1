using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    Animator animator;
    AIController aIController;
    NavMover navMover;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        aIController = GetComponent<AIController>();
        navMover = GetComponent<NavMover>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", navMover.Speed);
        bool attacking = false;
        if (aIController.activeTask is AttackTarget)
        {
            if (((aIController.activeTask) as AttackTarget).TargetInRange()) attacking = true;
        }

        animator.SetBool("Attacking", attacking);
    }
}