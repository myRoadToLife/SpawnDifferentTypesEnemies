using UnityEngine;

public class StalkingBehavior : Enemy, IActiveBehavior
{
    public void ActivateState()
    {
        Debug.Log("� ���������!");
    }

    public void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
