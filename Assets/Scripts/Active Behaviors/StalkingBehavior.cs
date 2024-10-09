using UnityEngine;

public class StalkingBehavior : Enemy, IActiveBehavior
{
    public void ActivateState()
    {
        Debug.Log("Я преследую!");
    }

    public void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
