using UnityEngine;

public class StandStillBehavior : IIdleBehavior
{
    public void IdleAction()
    {
        Debug.Log("Я остаюсь на месте!");
    }
}
