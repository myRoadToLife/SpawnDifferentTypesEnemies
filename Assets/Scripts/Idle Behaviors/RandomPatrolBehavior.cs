using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrolBehavior : MonoBehaviour, IIdleBehavior
{
    public void Idle()
    {
        Debug.Log("Я патрулирую случайные позиции.");
    }
}
