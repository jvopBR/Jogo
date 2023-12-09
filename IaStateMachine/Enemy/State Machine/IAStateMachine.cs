using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAStateMachine
{

    public IAState currentState{get; private set; } 

    public void Initilize (IAState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }
   

   public void ChangeState(IAState newIAState) 
   {
    currentState.Exit();
    currentState = newIAState;
    currentState.Enter();
   }
}
