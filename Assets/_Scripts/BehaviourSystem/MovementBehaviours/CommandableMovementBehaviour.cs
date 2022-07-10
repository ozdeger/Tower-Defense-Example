using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/ProgramableBehaviours/CommandableMovementBehaviour")]
public class CommandableMovementBehaviour : AMovementBehaviourSO
{
    [SerializeField] private float moveSpeed;
    
    public UnityEvent<BehaviourController> OnTargetReached { get; private set; } = new UnityEvent<BehaviourController>();
    public BehaviourController CommandedMoveTarget { get; set; }
    public override Vector2 TargetPoint 
    { 
        get 
        {
            if (CommandedMoveTarget == null) return Controller.transform.position;
            return CommandedMoveTarget.transform.position; 
        } 
    }
    public float MoveSpeed => moveSpeed;

    public override void OnSetup(BehaviourController controller)
    {
        //
    }

    public override void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public override void TickMove(float deltaTime)
    {
        if (!IsActive) return;
        if (!CommandedMoveTarget) return;

        Vector2 moveDirection = (TargetPoint - (Vector2)Controller.transform.position).normalized;
        Controller.transform.position = (Vector2)Controller.transform.position + (moveDirection * MoveSpeed * deltaTime);
        if (Vector2.Distance(Controller.transform.position, CommandedMoveTarget.transform.position) < MoveSpeed * deltaTime) TargetReached();
    }

    private void TargetReached()
    {
        OnTargetReached.Invoke(CommandedMoveTarget);
        OnTargetReached.RemoveAllListeners();
    }
}
