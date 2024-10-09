using UnityEngine;

public class DieOnContactBehavior : Enemy, IActiveBehavior
{
    public void ActivateState()
    {
        Debug.Log("Я умираю!");
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            ActivateState();
        }
    }
}
