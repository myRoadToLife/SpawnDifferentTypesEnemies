using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehavior _activeBehavior;
    private IBehavior _idleBehavior;
    private IBehavior _currentBehavior;

    public void Initialize(IBehavior idleBehavior, IBehavior activeBehavior)
    {
        _idleBehavior = idleBehavior;
        _activeBehavior = activeBehavior;
        InitializingBehavior();
    }

    private void InitializingBehavior()
    {
        _currentBehavior = _idleBehavior;
    }

    private void Update()
    {
        _currentBehavior?.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _currentBehavior = null;
            _currentBehavior = _activeBehavior;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _currentBehavior = null;
            _currentBehavior = _idleBehavior;
        }
    }

}