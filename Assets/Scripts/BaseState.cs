using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    public abstract void EnterState(BaseController baseController);

    public abstract void Update(BaseController baseController);
}
