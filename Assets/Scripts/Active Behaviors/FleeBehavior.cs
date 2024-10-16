using UnityEngine;

public class FleeBehavior : IActiveBehavior
{
    private Transform _player;
    private Transform _enemyTransform;

    private float _fleeSpeed = 0.5f;
    public FleeBehavior(Transform player, Transform enemy, float fleeSpeed)
    {
        _player = player;
        _enemyTransform = enemy;
        _fleeSpeed = fleeSpeed;
    }

    public void ActiveAction()
    {
        Vector3 directionToPlayer = _enemyTransform.position - _player.position;
        Vector3 fleeDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z).normalized;
        _enemyTransform.position += fleeDirection * _fleeSpeed * Time.deltaTime;

        Debug.Log("Я убегаю!");
    }
}
