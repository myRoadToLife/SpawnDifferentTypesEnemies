using UnityEngine;

public class PatrolBehavior : MonoBehaviour, IIdleBehavior
{
    public void Idle()
    {
        Debug.Log("Я патрулирую.");
    }
}