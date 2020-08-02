using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovingUpState : ElevatorBaseState
{
    public override void EnterState(ElevatorController elevator)
    {
        Debug.Log("Moving Up");
        Debug.Log(elevator.elevatorFloorStops[0].localPosition);
        Debug.Log(elevator.nextPos);
    
    }

    public override void OnCollisionEnter2D(ElevatorController elevator, Collision2D collision)
    {
    }

    public override void Update(ElevatorController elevator)
    {
        Move(elevator);
    }

    private void Move(ElevatorController elevator)
    {
        elevator.elevator.transform.localPosition = Vector3.MoveTowards(elevator.elevator.transform.localPosition, elevator.nextPos, elevator.speed * Time.deltaTime);
        if (Vector3.Distance(elevator.elevator.transform.localPosition, elevator.nextPos) <= 0)
        {
            if(elevator.currentPosition < elevator.positions.Count-1)
            {
                elevator.currentPosition += 1;
                elevator.nextPos = elevator.positions[elevator.currentPosition];
            }
            else
            {
                elevator.nextState = elevator.MovingDownState;
            }
            elevator.TransitionToState(elevator.StoppedState);
        }
    }
}
