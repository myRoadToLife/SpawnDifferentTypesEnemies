using UnityEngine;

public class DeathBehavior : MonoBehaviour, IActiveBehavior
{
    public void Activate()
    {
        Debug.Log("Я умираю");
    }
}
