using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

public class ElevatorController : MonoBehaviour
{
    public ElevatorBaseState currentState;
    public ElevatorBaseState CurrentState
    {
        get { return currentState; }
    }
    public ElevatorBaseState nextState;
    public ElevatorBaseState NextState
    {
        get { return nextState; }
    }

    public List<Transform> elevatorFloorStops = new List<Transform>();
    [HideInInspector]
    public List<Vector3> positions = new List<Vector3>();
    public GameObject elevator;
    [HideInInspector]
    public Vector3 nextPos;
    [HideInInspector]
    private Vector3 posA;
    [HideInInspector]
    private Vector3 posB;
    [HideInInspector]
    public int currentPosition = 0;
    public float speed;
    WaitForSeconds wait = new WaitForSeconds(2);
    // STATES
    // movingUp, movingDown, stopped.
    public readonly ElevatorStoppedState StoppedState = new ElevatorStoppedState();
    public readonly ElevatorMovingUpState MovingUpState = new ElevatorMovingUpState();
    public readonly ElevatorMovingDownState MovingDownState = new ElevatorMovingDownState();
    
    void Start()
    {   
        foreach(Transform elevatorFloor in elevatorFloorStops)
        {
            positions.Add(elevatorFloor.localPosition);
        }
        posA = positions[0];
        posB = positions[1];
        
        TransitionToState(StoppedState);
        nextState = MovingUpState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
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

    public ElevatorBaseState StateController()
    {
        if (nextState == MovingUpState)
        {
            return MovingUpState;
        }
        if (nextState == MovingDownState )
        {
            return MovingDownState;
        }
        return StoppedState;
    }
}
