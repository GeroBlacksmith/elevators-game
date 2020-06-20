using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovingDownState : ElevatorBaseState
{
    public override void EnterState(ElevatorController elevator)
    {
        Debug.Log("Moving Down");
    }

    public override void OnCollisionEnter2D(ElevatorController elevator, Collision2D collision)
    {
    }

    public override void Update(ElevatorController elevator)
    {
    }
}
