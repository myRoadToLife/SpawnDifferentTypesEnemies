using UnityEngine;

public class PatrolBehavior : Enemy, IIdleBehavior
{
    public void IdleState()
    {
        Debug.Log("Я патрулирую.");
    }
}