using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElevatorBaseState 
{
    public abstract void EnterState(ElevatorController elevator);
    public abstract void Update(ElevatorController elevator);
    public abstract void OnCollisionEnter2D(ElevatorController elevator, Collision2D collision);
}
