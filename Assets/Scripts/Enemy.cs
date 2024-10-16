using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IIdleBehavior _idleBehavior;
    private IActiveBehavior _activeBehavior;

    private bool _isActive = false;

    public void Initialize(IIdleBehavior idle, IActiveBehavior active)
    {
        _idleBehavior = idle;
        _activeBehavior = active;
    }

    private void Update()
    {

        if (_isActive)
        {
            _activeBehavior?.ActiveAction();
        }
        else
        {
            _idleBehavior?.IdleAction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) && !_isActive)
        {
            _isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) && _isActive)
        {
            _isActive = false;
        }
    }

}