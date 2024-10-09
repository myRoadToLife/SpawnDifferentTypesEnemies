using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkingBehavior : MonoBehaviour, IActiveBehavior
{
    public void Activate()
    {
        Debug.Log("Я преследую!");
    }
}
