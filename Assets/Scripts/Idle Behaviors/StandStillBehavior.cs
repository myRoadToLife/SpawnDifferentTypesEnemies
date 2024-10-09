using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandStillBehavior : MonoBehaviour, IIdleBehavior
{
    public void Idle()
    {
        Debug.Log("Я стою на месте!");
    }
}
