using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public BaseState currentState;
    public BaseState CurrentState
    {
        get { return currentState; }
    }
    void Start()
    {
        
    }

    void Update()
    {
        currentState.Update(this);
    }
    public void TransitionToState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
        Debug.Log(currentState);
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    */
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        currentState.OnCollisionExit2D(this, collision);
    }
    */
    //OnTriggerEnter2D
    //OnTriggerExit2D
}
