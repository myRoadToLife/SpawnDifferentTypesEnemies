using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IIdleBehavior idleBehavior;
    private IActiveBehavior activeBehavior;

    public void Initialize(IIdleBehavior idle, IActiveBehavior active)
    {
        idleBehavior = idle;
        activeBehavior = active;
    }

    //public void PerformIdle()
    //{
    //    if (idleBehavior != null)
    //    {
    //        idleBehavior.IdleState();
    //    }
    //}

    //public void PerformActive()
    //{
    //    if (activeBehavior != null)
    //    {
    //        activeBehavior.ActivateState();
    //    }
    //}
}
