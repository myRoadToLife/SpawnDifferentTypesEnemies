using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : Enemy, IActiveBehavior
{
    public void ActivateState()
    {
        Debug.Log("Я убегаю");
    }

    public void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
