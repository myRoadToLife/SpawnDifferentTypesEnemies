using UnityEngine;

public class RandomWalkBehavior : Enemy, IIdleBehavior
{
    public void IdleState()
    {
        Debug.Log("Я патрулирую случайные позиции.");
    }
}
