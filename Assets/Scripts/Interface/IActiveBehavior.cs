using UnityEngine;

public interface IActiveBehavior
{
    public void ActivateState();
    public void OnTriggerEnter(Collider other);
}
