using UnityEngine;

public class FleeBehavior : IBehavior
{
    private Transform _player;
    private Transform _enemyTransform;

    private float _fleeSpeed = 3f;

    public FleeBehavior(Transform player, Transform enemy)
    {
        _player = player;
        _enemyTransform = enemy;
    }

    public void Update()
    {
        MoverAway();
    }

    private void MoverAway()
    {
        Vector3 directionToPlayer = _enemyTransform.position - _player.position;
        Vector3 fleeDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z).normalized;
        _enemyTransform.position += fleeDirection * _fleeSpeed * Time.deltaTime;
    }
}
