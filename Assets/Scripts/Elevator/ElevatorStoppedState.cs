using System.Collections;
using UnityEngine;

public class ElevatorStoppedState : ElevatorBaseState
{
   
    public override void EnterState(ElevatorController elevator)
    {
        elevator.DelayedTransition(elevator.StateController());
        //elevator.DelayedTransition(elevator.MovingUpState);
        Debug.Log("Stopped");
    }

    public override void OnCollisionEnter2D(ElevatorController elevator, Collision2D collision)
    {
        
    }

    public override void Update(ElevatorController elevator)
    {
    }

    
}
