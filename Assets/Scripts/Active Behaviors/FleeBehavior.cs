using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : MonoBehaviour, IActiveBehavior
{
    public void Activate()
    {
        Debug.Log("Я убегаю");
    }
}
