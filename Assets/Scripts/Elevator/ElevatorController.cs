using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public ElevatorBaseState currentState;
    public ElevatorBaseState CurrentState
    {
        get { return currentState; }
    }

    WaitForSeconds wait = new WaitForSeconds(2);
    // STATES
    // movingUp, movingDown, stopped.
    public readonly ElevatorStoppedState StoppedState = new ElevatorStoppedState();
    public readonly ElevatorMovingUpState MovingUpState = new ElevatorMovingUpState();
    public readonly ElevatorMovingDownState MovingDownState = new ElevatorMovingDownState();

    void Start()
    {
        TransitionToState(StoppedState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }
    public void TransitionToState(ElevatorBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);

    }
    public void DelayedTransition(ElevatorBaseState state)
    {
        StartCoroutine(Wait(state));
        
        
        
    }
    private IEnumerator Wait(ElevatorBaseState state)
    {
        yield return wait;
        currentState = state;
        currentState.EnterState(this);
        
    }
}
