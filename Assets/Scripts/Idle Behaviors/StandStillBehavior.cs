using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandStillBehavior : MonoBehaviour, IIdleBehavior
{
    public void Idle()
    {
        Debug.Log("Стою на месте!");
    }
}
