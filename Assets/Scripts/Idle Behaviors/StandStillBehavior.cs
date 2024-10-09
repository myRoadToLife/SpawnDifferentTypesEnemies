using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandStillBehavior : Enemy, IIdleBehavior
{
    public void IdleState()
    {
        Debug.Log("Я стою на месте!");
    }
}
